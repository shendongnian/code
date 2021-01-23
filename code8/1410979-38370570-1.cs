    using UnityEngine;
    using System.Collections;
    
    public class ClickManager : MonoBehaviour
    {
        public float dragSpeed = 2;
        public float minZoom = 0.5f;
        public float maxZoom = 5.0f;
    
        private Vector3 dragOrigin;
    
        private float lerpPercentBack = 0; 
        private float lerpPercentForward = 0;
        private bool isLerpingBack = false;
        private bool isLerpingForward = false;
    
        Vector3 forwardPos;
        Vector3 backwardPos;
        void Start()
        {
            forwardPos = transform.position ;
            forwardPos.z += maxZoom;
    
            backwardPos = transform.position ;
            backwardPos.z += minZoom;
        }
    
    
        void Update()
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
    
            if (Input.GetMouseButtonDown(1))
            {
                dragOrigin = Input.mousePosition;
                return;
            }
    
            if (scroll > 0)
            {
                isLerpingForward = true;
                lerpPercentForward = 0;
            }
            if (scroll < 0)
            {
                isLerpingBack = true;
                lerpPercentBack = 0;
            }
    
    
    
            if (isLerpingBack)
            {
                scrollLerperBack();
                lerpPercentBack += 0.05f;
    
                if (lerpPercentBack >= 1.0f)
                {
                    lerpPercentBack = 0;
                    isLerpingBack = false;
                }
            }
    
    
            if (isLerpingForward)
            {
    
                scrollLerperForward();
                lerpPercentForward += 0.05f;
    
                if (lerpPercentForward >= 1.0f)
                {
                    lerpPercentForward = 0;
                    isLerpingForward = false;
                }
            }
        }
    
    
        void scrollLerperBack()
        {
            transform.position = Vector3.MoveTowards(transform.position, backwardPos, Time.deltaTime * dragSpeed );
        }
    
    
        void scrollLerperForward()
        {
            transform.position = Vector3.MoveTowards(transform.position, forwardPos, Time.deltaTime * dragSpeed);
        }
    
    
    }
