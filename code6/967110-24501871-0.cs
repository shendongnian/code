    using UnityEngine;
    using System.Collections;
    
    public class ExampleClass : MonoBehaviour {
        void Example() {
            foreach (Transform child in transform) {
                child.gameObject.name = "foo";
                // or do something else with child.gameObject
            }
        }
    }
