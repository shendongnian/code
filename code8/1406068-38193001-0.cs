    public class Player : MonoBehaviour
    {
        public LayerMask groundLayer;
        Collider2D playerCollider;
        bool grounded;
    
        void Start()
        {
            playerCollider = gameObject.GetComponent<Collider2D>();
        }
    
        public bool IsGrounded()
        {
            grounded = Physics2D.OverlapCircle(playerCollider.transform.position, 1, groundLayer);
            return grounded;
        }
    }
