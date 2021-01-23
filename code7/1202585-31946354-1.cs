    using UnityEngine;
    using System.Collections;
    public class Example : MonoBehaviour {
     int myExample;
     // Use this for initialization
     void Start () {
      myExample = 1;
     }
     // Update is called once per frame
     void Update () {
      myExample = Example * 2;
      Debug.Log(myExample);
     }
    }
