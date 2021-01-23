    using UnityEngine;
    using System.Collections;
    public class p1 : MonoBehaviour {
      public float hiz = 2.0f; //movement per second
      Vector2 v2Pozisyon;
      void Start () {
      }
      void Update () {
        yuru ();
      }
      void yuru (){
        if (Input.GetKey (KeyCode.LeftArrow)) {
            v2Pozisyon.x = this.transform.localPosition.x - hiz * Time.deltaTime;
        }
        if (Input.GetKey (KeyCode.RightArrow)) {
            v2Pozisyon.x = this.transform.localPosition.x + hiz * Time.deltaTime;
        }
      }
    }
