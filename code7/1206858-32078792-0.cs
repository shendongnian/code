    using UnityEngine;
    public class ClickDetector:MonoBehaviour {
        public int button=0;
        public float clickSize=50; // this might be too small
        void ClickHappened() {
            Debug.Log("CLICK!");
        }
        Vector3 pos;
        void Update() {
          if(Input.GetMouseButtonDown(button))
            pos=Input.mousePosition;
          if(Input.GetMouseButtonUp(button)) {
            var delta=Input.mousePosition-pos;
            if(delta.sqrMagnitude < clickSize*clickSize)
              ClickHappened();
          }
        }
    }
