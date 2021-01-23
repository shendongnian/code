    using UnityEngine;
    using System.Collections;
    
    public class Tilt : MonoBehaviour 
    {
        float speed = 1.0f;
        float rotationAngle = 45;
        void Update()
        {
            Tilter ();
        }
    
        void Tilter()
        {
            float rotationZ = rotationAngle * Mathf.Sin(Time.time * speed);
            transform.Rotate (new Vector3 (0f, 0f, rotationZ ));
        }
    
    }
