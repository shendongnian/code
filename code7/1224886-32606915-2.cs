    using UnityEngine;
    using System.Collections;
    
    [RequireComponent(typeof(BoxCollider2D))]
    public class TouchInput : MonoBehaviour
    {
        private Vector3 screenPoint;
        private Vector3 initialPosition;
        private Vector3 offset;
        public float speed = 20.0f;
    
        Rigidbody2D rb;
    
        void Start()
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
        }
    
        void OnMouseDown()
        {
            Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 initialPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        }
    
        void OnMouseDrag()
        {
            Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
            Vector3 heading = cursorPosition - initialPosition;
            Vector3 direction = heading / heading.magnitude; // heading magnitude = distance 
            rb.velocity = new Vector3(150 * Time.deltaTime, 0, 0);
            //Do what you want.
            //if you want to drag object on only swipe gesture comment below. Otherwise:
            initialPosition = cursorPosition;
        }
    
        void OnMouseUp()
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }
