    public class MovingObject : MonoBehaviour {
        private Vector3 prevPosition;
    
        void Start() {
            // Starting off last position as current position
            prevPosition = transform.position;
        }
    
        void Update() {
            // Calculate position change between frames
            Vector3 deltaPosition = transform.position - prevPosition;
            if (deltaPosition != Vector3.zero) {
                // Same effect as rotating with quaternions, but simpler to read
                transform.forward = deltaPosition;
            }
            // Recording current position as previous position for next frame
            prevPosition = transform.position;
        }
    }
