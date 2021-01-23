    using UnityEngine;
    using System.Collections;
    
    public class ExampleClass : MonoBehaviour {
        public Rigidbody rigid;
        Vector3 yourVelocityVariable;
    
        void Start() {
            rigid = GetComponent<Rigidbody>();
        }
        void FixedUpdate() {
            rigid.velocity = yourVelocityVariable;            
        }
    }
