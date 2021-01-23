    using UnityEngine;
    using System.Collections;
    
    public class Example : MonoBehaviour {
        public int example;
        // Use this for initialization
        void Start()
        {        
            example = 1;
        }
        // Update is called once per frame
        void Update()
        {
            example = example * 2;
            Debug.Log(example);
        }
    }
