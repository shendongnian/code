    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class CameraMovement : MonoBehaviour {
        private Vector3 InitialClickPosition;
        private bool Pan = false;
        private const int MOUSE_BUTTON = 0;
        private void LateUpdate()
        {
            if (Input.GetMouseButtonDown(MOUSE_BUTTON))
            {
                InitialClickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            else if (Input.GetMouseButton(MOUSE_BUTTON))
            {
                var difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Camera.main.transform.position;
                Camera.main.transform.position = InitialClickPosition - difference;
            }
        }
    }
