    using UnityEngine;
    using System.Collections;
    
    public class CameraFollower : MonoBehaviour
    {
        public Transform thePlayer;
    
        private Vector3 offset;
    
        void Start()
        {
            offset = transform.position - thePlayer.position;
        }
    
        void Update()
        {
            Vector3 cameraNewPosition = new Vector3(thePlayer.position.x + offset.x, offset.y, thePlayer.position.z + offset.z);
            transform.position = cameraNewPosition;
        }
    }
