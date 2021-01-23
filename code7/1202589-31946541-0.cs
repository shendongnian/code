    using UnityEngine;
    using System.Collections;
    public class Example : MonoBehaviour { // <---- Class name is capitalized so dont use same capitalization for "example" inside of class
        int example;  // <----- Put example here so it exists throughout the whole class
        // Use this for initialization
        void Start () {
            example = 1; // <---- initialization
        }
        // Update is called once per frame
        void Update () {
            Debug.Log(example *= 2); // <------- Code shortening FTW
        }
    }
