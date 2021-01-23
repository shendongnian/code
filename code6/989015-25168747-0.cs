    using UnityEngine;
    using System.Collections;
    public class DayNight : MonoBehaviour{
        private float smooth = 0.0000000000005;
        // Use this for initialization
        void start (){
    
        }
 
        float accumulate = 0;
        // Update is called once per frame
        void Update () 
        {
    
            float intensityA = 0.05f;
            float intensityB = 5f;
            accumulate += Time.deltaTime;
            light.intensity = Math.Lerp(intensityA, intensityB, smooth * accumulate);
            
    
        }
    }
