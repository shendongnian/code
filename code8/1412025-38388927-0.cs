        using UnityEngine;
        using System.Collections;
        
        public class ExampleClass : MonoBehaviour {
        public bool mybool;
            void Update() {
                if (Input.GetKeyDown(KeyCode.F))
                    GetComponent<Light> ().enabled = !mybool;
                
            }
    }
