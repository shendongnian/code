    using UnityEngine;
    using System.Collections;
    public class MoveMissile : MonoBehaviour {
    // Use this for initialization
    public float speed = 0.5F;
    public Transform Shotspawn;
      void Start (){
       // Sets the direction that shot is fired in.
      transform.rotation=Shotspawn.rotation;
      }
      // Update is called once per frame
      void Update () {
      transform.Translate(Vector2.up * speed);
     }
    }
