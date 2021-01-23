    using UnityEngine;
    using System.Collections;
    public class EnemyControl : MonoBehaviour {
       float speed;
  
        void Start () {
          speed = 2.0f;
    }
    // Update is called once per frame
    void FixedUpdate () {
       
        godown();
        
    }
    void godown() {
        transform.position += Vector3.down *speed* Time.deltaTime;
    }
