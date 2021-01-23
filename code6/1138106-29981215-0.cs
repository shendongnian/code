    using UnityEngine;
    using System.Collections;
    
    public class ExampleClass : MonoBehaviour {
        public TextAsset asset;
        void Start() {
            print(asset.text);
        }
    }
