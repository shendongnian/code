    using UnityEngine;
    using System.Collections;
    
    public class ShipController : MonoBehaviour {
    
        public Quaternion originalRotation;
    
        void Start () {
            originalRotation = transform.rotation;
        }
    
        void Update()
        {
            if (Input.GetKey (KeyCode.LeftArrow)) {
                transform.Rotate (Vector3.down * turnRate * Time.deltaTime);
            }
            if (Input.GetKey (KeyCode.RightArrow)) {
                transform.Rotate (Vector3.up * turnRate * Time.deltaTime);
            }
            if (Input.GetKey (KeyCode.UpArrow)) {
                transform.Rotate (Vector3.left * turnRate * Time.deltaTime);
            }
            if (Input.GetKey (KeyCode.DownArrow)) {
                transform.Rotate (Vector3.right * turnRate * Time.deltaTime);
            }
            transform.rotation = Quaternion.RotateTowards(transform.rotation, originalRotation, 1.0f * Time.deltaTime);
        }
    }
