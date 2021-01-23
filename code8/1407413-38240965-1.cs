    using UnityEngine;
    using System.Collections;
    
    public class CharacterController : MonoBehaviour
    {
        public float inputDelay = 0.1f;
        public float forwardVel = 12;
        public float rotateCel = 12;
        public float jumpHeight = 10;
        private float jumpTime;
        public float _initialJumpTime = 0.4f;
        //[HideInInspector]
        public bool isGrounded;
        Quaternion targetRotation;
        Rigidbody rBody;
        Vector3 forwardInput, turnInput;
        public bool canJump;
    
        public Quaternion TargetRotation
        {
            get { return targetRotation; }
        }
    
        void Start()
        {
            targetRotation = transform.rotation;
            if (GetComponent<Rigidbody>())
                rBody = GetComponent<Rigidbody>();
            else
            {
                Debug.LogError("Character Needs Rigidbody");
            }
    
            //  forwardInput = turnInput = 0;
            forwardInput = turnInput = Vector3.zero;
        }
    
        void Update()
        {
            GetInput();
            //Turn ();
    
            if (Input.GetKeyDown(KeyCode.Space) && canJump)
            {
                rBody.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            }
        }
    
    
        void GetInput()
        {
            //forwardInput = Input.GetAxis ("Vertical");
            //turnInput = Input.GetAxis ("Horizontal");
            forwardInput = new Vector3(Input.GetAxis("Horizontal") * rotateCel, 0, Input.GetAxis("Vertical") * forwardVel);
            forwardInput = transform.TransformDirection(forwardInput);
        }
    
        void FixedUpdate()
        {
            //Run();
        }
    
        void Run()
        {
            //HERE YOU SET THE RIGIDBODYS VELOCITY, WHICH IS CAUSING YOUR JUMP TO NOT WORK PROPERLY. DO NOT MODIFY THE VELOCITY
            //OF A RIGIDBODY
            if (Mathf.Abs(10) > inputDelay)
            {
                //Move
                //rBody.velocity = transform.forward * forwardInput * forwardVel;
                rBody.velocity = forwardInput;
            }
            else
            {
                //zero velocity
                rBody.velocity = Vector3.zero;
            }
        }
    
        void Turn()
        {
            //  targetRotation *= Quaternion.AngleAxis (rotateCel * turnInput * Time.deltaTime, Vector3.up);
            //  transform.rotation = targetRotation;
        }
    
        void OnCollisionEnter(Collision col)
        {
            isGrounded = true;
            canJump = true;
        }
    
        void OnCollisionExit(Collision col)
        {
            isGrounded = false;
            canJump = false;
        }
    }
