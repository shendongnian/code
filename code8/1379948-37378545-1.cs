    using UnityEngine;
    using System.Collections;
    
    public class MyObject : MonoBehaviour
    {
        // Custom reticle events
        void OnReticleEnter()
        {
            Debug.Log("Entering over " + this.name);
        }
        void OnReticleExit()
        {
            Debug.Log("Exiting over "+this.name);
        }
        void OnReticleHover()
        {
            Debug.Log("Hovering over "+this.name);
        }
    }
