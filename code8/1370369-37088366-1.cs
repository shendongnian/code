    public class CameraMovement : MonoBehaviour {
        Transform rotAround;
        private Vector3 startPosition;
        public float maxRotation = 0; // set this to the maximum angle in degrees
        void Start () 
        {
            rotAround = GameObject.Find ("CamRotation").GetComponent <Transform> ();
            startPosition = transform.position;
        }
    
        
        void Update () 
        {
             
            float currentAngle = Vector3.Angle(rotAround.position - startPosition,
                                               rotAround.position - transform.position));
            if (Input.GetKey (KeyCode.D) && maxRotation < currentAngle) 
            {
                transform.RotateAround (rotAround.position, Vector3.down, 100 * Time.deltaTime);
            }
            if (Input.GetKey (KeyCode.A) && maxRotation < currentAngle) 
            {
                transform.RotateAround (rotAround.position, Vector3.up, 100 * Time.deltaTime);
            }
        }
    }
