    using UnityEngine;
    using System.Collections;
    
    public class PixelMovement : MonoBehaviour {
    
        public float playerSpeed;
        public Vector3 gravity;
        public float maxSpeed = 5f;
        Vector3 velocity = Vector3.zero;
        public float fowardSpeed = 1f;
    
        bool didPress = false;
    
        void Update()
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                didPress = true;
            }
            else
            {
                didPress = false;
            }
        }
    
        void FixedUpdate()
        {
            velocity.x = fowardSpeed;
            transform.position += velocity * Time.deltaTime;
            if (didPress == true)
            {
                
                float amntToMove1 = playerSpeed * Time.deltaTime;
                transform.Translate(Vector3.up * amntToMove1);
            }
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
            transform.position += velocity * Time.deltaTime;
        }
    }
