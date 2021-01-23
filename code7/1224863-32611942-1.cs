    using UnityEngine;
    using System.Collections;
    
    public class cameraScript : MonoBehaviour {
        public float camYLerpTime = 5f;
        float camYLerpProg = 0;
        float camYInitPoint = 950f;
        public float camYEndPoint = 0f;
        float camPosY;
        //float camFieldOfViewStable = 170.5f;
    
        // Use this for initialization
        void Start () {
        }
    
        // Update is called once per frame
        void LateUpdate () {
            if (transform.position.y!=camYEndPoint) {
                camYLerpProg += Time.deltaTime;
                float camPosY = Mathf.Lerp (camYInitPoint, camYEndPoint, camYLerpProg / camYLerpTime);
                transform.position = new Vector3 (transform.position.x, camPosY, transform.position.z);
            }
        }
    }
