    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class ScriptName : MonoBehaviour {
        //Variables
        public float floatName = 0;
        void OnDrawGizmosSelected () {
            if (floatName < 0) {
                floatName = 0;
            }
        }
    }
