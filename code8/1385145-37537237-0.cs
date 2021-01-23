    public class CameraMover: MonoBehaviour
    {
        public Transform playerTransform;
        public Transform mainCameraTransform = null;
        private Vector3 cameraOffset = Vector3.zero;
    
        void Start()
        {
    
            mainCameraTransform = Camera.main.transform;
    
            //Get camera-player Transform Offset that will be used to move the camera 
            cameraOffset = mainCameraTransform.position - playerTransform.position;
        }
    
        void LateUpdate()
        {
            //Move the camera to the position of the playerTransform with the offset that was saved in the begining
            mainCameraTransform.position = playerTransform.position + cameraOffset;
        }
    }
