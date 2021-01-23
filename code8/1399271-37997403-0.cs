    using UnityEngine;
    using System.Collections;
    
    public class PlayerController : MonoBehaviour
    {
        public float jumpPower = 2f;
    
        [SerializeField]
        public bool isGrounded = true;
    
        [SerializeField]
        private LayerMask groundLayer, waterLayer;
    
        private int numSpacePress = 0;
        private Rigidbody2D rb;
    
        // Ground Checker Stuff
        public Transform groundChecker;
        public float groundCheckRadius = 0.1f;
    
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }
    
        void Update()
        {
    Collider2D[] hits = Physics2D.OverlapCircleAll(groundChecker.position, groundCheckRadius);
    
            foreach (Collider2D hit in hits)
            {
                if (hit.gameObject != gameObject)
                {
                    Debug.Log("Hit = " + hit.gameObject.name);
                    if (((1 << hit.GetComponent<Collider2D>().gameObject.layer) & groundLayer) != 0)
                    {
                        isGrounded = true;
                        numSpacePress = 0;
                    }
                }
            }
    
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded && numSpacePress < 2)
            {
                numSpacePress++;
                Debug.Log("Num spaces pressed = " + numSpacePress);
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                if (numSpacePress >= 2)
                {
                    isGrounded = false;
                }
            }
        }
    } 
