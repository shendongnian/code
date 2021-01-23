    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class DoorOpen : MonoBehaviour {
    
        public bool openclosed;
        public float angle;
        
    
        public bool InDistance;
    
        private void Start()
        {
            
            openclosed = false;
        }
    
        private void OnTriggerEnter(Collider other)
        {
            InDistance = true;
        }
        private void OnTriggerExit(Collider other)
        {
            InDistance = false;
        }
    
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && InDistance == true && openclosed == false)
            {
                openclosed = true;
                transform.Rotate(0, 0, angle);
            }
    
            else if (Input.GetKeyDown(KeyCode.E) && openclosed == true && InDistance == true)
            {
                openclosed = false;
                transform.Rotate(0, 0, -angle);
            }
    
    
        }
    
    
    
    
    
    
    }
