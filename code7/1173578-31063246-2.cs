    using UnityEngine;
    using System.Collections;
    public class PlayerController : MonoBehaviour {
        protected bool rotate = false;
        public void CubeRotate () {
            rotate = !rotate;
        }
        public void Update() {
            if(rotate)
            {
                transform.Rotate (new Vector3 (150, 300, 60) * Time.deltaTime);
            }
        }
    }
