    using UnityEngine;
    using System.Collections;
    
    public class PlayerController : MonoBehaviour {
    
        public float speed;    // Here we set a float variable to hold our speed value
    
        private Rigidbody rb;  // This is to hold the rigidbody component
    
        // Start is called as you start the game, we use it to initially give values to things
        void Start ()
        {
            rb = GetComponent<Rigidbody>();  // Here we actually reference the rigidbody.
        }
    
        void FixedUpdate ()
        {
            // We assign values based on our input here:
            float moveHorizontal = Input.GetAxis ("Horizontal");
            float moveVertical = Input.GetAxis ("Vertical");
    
            // Here we assign those values to a Vector2 variable.
            Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
    
            rb.AddForce (movement * speed);    // Finally we apply the forces to the rigidbody
        }
    }
