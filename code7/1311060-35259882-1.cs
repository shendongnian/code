    using UnityEngine;
    using System.Collections;
    public class RotateCylinder : MonoBehaviour
    {
        // rotation speed in degrees per second.
        private float rotationSpeed = 1f;
        void Update()
        {
            // Use one of the following depending on the axis you want to rotate the object, this will depend on how your object is transformed.
            // Rotate around X Axis
            transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
            // Rotate around Y Axis
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            // Rotate around Z Axis
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }
