    using UnityEngine;
    using System.Collections;
    
    public class ExampleClass : MonoBehaviour {
        public float yRotation = 5.0F;
        void Update() {
            yRotation += Input.GetAxis("Horizontal");
            transform.eulerAngles = new Vector3(10, yRotation, 0);
        }
        void Example() {
            print(transform.eulerAngles.x);
            print(transform.eulerAngles.y);
            print(transform.eulerAngles.z);
        }
    }
