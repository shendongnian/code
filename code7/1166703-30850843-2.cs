    using UnityEngine;
    using System.Collections;
    public class ExampleClass : MonoBehaviour {
        public float thrust;
        public Rigidbody rb;
        void Start() {
            // Get the instance here and stores it as a class member.
            rb = GetComponent<Rigidbody>();
        }
        void FixedUpdate() {
            // Re-use the member to access the non-static method
            rb.AddForce(transform.forward * thrust);
        }
    }
