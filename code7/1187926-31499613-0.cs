    public class PlayerController : MonoBehaviour{
    public float runSpeed = 6.0F;
    public float jumpHeight = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    // Added
    private CharacterController controller;
    private Animator animController;
        
