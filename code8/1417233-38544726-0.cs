    using UnityEngine;
    using System;
    
    public class MouseLook : MonoBehaviour {
        [Flags]
        public enum RotationAxes
        {
            None,
            LeftAndRight,
            UpAndDown,
            Both = LeftAndRight + UpAndDown
        }
    
        public RotationAxes axes = RotationAxes.Both;
        public float horizontalSensitivity = 9f;
        public float verticalSensitivity = 9f;
        public float verticalMinimum = -45f;
        public float verticalMaximum = 45f;
    
        float pitch;
    
        // Update is called once per frame
        void Update () {
            float yaw = transform.localEulerAngles.y;
            if ((axes & RotationAxes.LeftAndRight) != 0)
                yaw += Input.GetAxis("Mouse X") * horizontalSensitivity;
    
            if ((axes & RotationAxes.UpAndDown) != 0)
            {
                float pitchDelta = -Input.GetAxis("Mouse Y") * verticalSensitivity;
                pitch += pitchDelta;
                pitch = Mathf.Clamp(pitch, verticalMinimum, verticalMaximum);
            }
            transform.localEulerAngles = new Vector3(pitch, yaw, 0);
        }
    }
