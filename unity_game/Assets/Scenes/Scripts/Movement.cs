using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private InputAction moveAction;

    [SerializeField] private float speed = 5f;

    void Awake()
    {
        rb = GetComponentInChildren<Rigidbody2D>();

        moveAction = new InputAction(
            name: "Move",
            type: InputActionType.Value,
            binding: "<Keyboard>/wasd"
        );

        moveAction.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");
    }

    void OnEnable()
    {
        moveAction.Enable();
    }

    void OnDisable()
    {
        moveAction.Disable();
    }

    void FixedUpdate()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();

        if (direction.sqrMagnitude > 1f)
            direction.Normalize();

        rb.linearVelocity = direction * speed;
    }
}
