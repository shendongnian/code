    using UnityEngine;
    using System.Collections;
    public class PlayerController : MonoBehaviour {
        bool rotate = false;
        public  void Update() {
            if(Input.GetMouseButtonDown(0))
            {
                rotate = !rotate;
            }
            if(rotate)
            {
                transform.Rotate (new Vector3 (150, 300, 60) * Time.deltaTime);
            }
        }
    }
