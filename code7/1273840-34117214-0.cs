    public class balance : MonoBehaviour {
         public float torque;
         public Rigidbody rb;
         private Vector3 prefFrameRotation;
         private Vector3 deltaRotation;
    
         void Start() {
             Input.gyro.enabled = true;
             deltaRotation = Vector3.zero;
             rb = GetComponent<Rigidbody>();
         }
         void FixedUpdate() 
             deltaRotation = prefFrameRotation - Input.gyro.attitude;
             //you don't even need to use Time.fixedDeltaTime because
             //the calculations are per fixedUpdate anyways
             rb.transform.Rotate(deltaRotation.x, 0, deltaRotation.z);
             prefFrameRotation = Input.gyro.attitude;
         }
    }
