    #define USEWITHSECENE
    
    using UnityEngine;
    using System.Collections;
    
    public class VRCAMRESTORE : MonoBehaviour
    {
    
        [System.Serializable]
        class VRInfo
        {
            //Transform Info
            [SerializeField]
            public Vector3 mainCameraPos;
            [SerializeField]
            public Vector3 mainCameraLeftPos;
            [SerializeField]
            public Vector3 mainCameraRightPos;
            [SerializeField]
            public Vector3 reticleUnderMainCameraPos;
    
            [SerializeField]
            public Vector3 PreRenderCameraUnderStereoRenderPos;
            [SerializeField]
            public Vector3 PostRenderCameraUnderStereoRenderPos;
    
            //Rotation Info
            [SerializeField]
            public Quaternion mainCameraRot;
            [SerializeField]
            public Quaternion mainCameraLeftRot;
            [SerializeField]
            public Quaternion mainCameraRightRot;
            [SerializeField]
            public Quaternion reticleUnderMainCameraRot;
    
            [SerializeField]
            public Quaternion PreRenderCameraUnderStereoRenderRot;
            [SerializeField]
            public Quaternion PostRenderCameraUnderStereoRenderRot;
        }
    
    
        public Camera mainCamera;
        public Camera mainCameraLeft;
        public Camera mainCameraRight;
        public GameObject reticleUnderMainCamera;
    
        public Camera PreRenderCameraUnderStereoRender;
        public Camera PostRenderCameraUnderStereoRender;
    
        private VRInfo vrInfo = null;
        private Transform c1, c2, c3, c4, c5, c6;
    
        //Use this for initialization
        void Start()
        {
            intitTransform();
            vrInfo = new VRInfo();
    
            //check if vrInfo exist
            string savedJsonValue = PlayerPrefs.GetString("vrInfo");
            if (savedJsonValue == null)
            {
                updateCamTransform();
                return;
            }
    
    
            //Convert back to class
            vrInfo = JsonUtility.FromJson<VRInfo>(savedJsonValue);
    
            //If Null, dont load the saved location
            if (vrInfo == null)
            {
                updateCamTransform();
                return;
            }
    
            //Load Aettings from the Savings
            loadTransform();
        }
    
        public void reset()
        {
            PlayerPrefs.DeleteKey("vrInfo");
        }
    
        void intitTransform()
        {
            c1 = mainCamera.GetComponent<Transform>();
            c2 = mainCameraLeft.GetComponent<Transform>();
            c3 = mainCameraRight.GetComponent<Transform>();
            c4 = reticleUnderMainCamera.GetComponent<Transform>();
            c5 = PreRenderCameraUnderStereoRender.GetComponent<Transform>();
            c6 = PostRenderCameraUnderStereoRender.GetComponent<Transform>();
        }
    
        private void loadTransform()
        {
            c1.position = vrInfo.mainCameraPos;
            c1.rotation = vrInfo.mainCameraRot;
    
            c2.position = vrInfo.mainCameraLeftPos;
            c2.rotation = vrInfo.mainCameraLeftRot;
    
            c3.position = vrInfo.mainCameraRightPos;
            c3.rotation = vrInfo.mainCameraRightRot;
    
            c4.position = vrInfo.reticleUnderMainCameraPos;
            c4.rotation = vrInfo.reticleUnderMainCameraRot;
    
            c5.position = vrInfo.PreRenderCameraUnderStereoRenderPos;
            c5.rotation = vrInfo.PreRenderCameraUnderStereoRenderRot;
    
            c6.position = vrInfo.PostRenderCameraUnderStereoRenderPos;
            c6.rotation = vrInfo.PostRenderCameraUnderStereoRenderRot;
        }
    
        bool firstRun = true;
    
        private void updateCamTransform()
        {
            //Prevents vrInfo == null from running every frame
            if (firstRun)
            {
                firstRun = false;
                if (vrInfo == null)
                {
                    vrInfo = new VRInfo();
                }
            }
    
            vrInfo.mainCameraPos = c1.position;
            vrInfo.mainCameraRot = c1.rotation;
    
            vrInfo.mainCameraLeftPos = c2.position;
            vrInfo.mainCameraLeftRot = c2.rotation;
    
            vrInfo.mainCameraRightPos = c3.position;
            vrInfo.mainCameraRightRot = c3.rotation;
    
            vrInfo.reticleUnderMainCameraPos = c4.position;
            vrInfo.reticleUnderMainCameraRot = c4.rotation;
    
            vrInfo.PreRenderCameraUnderStereoRenderPos = c5.position;
            vrInfo.PreRenderCameraUnderStereoRenderRot = c5.rotation;
    
            vrInfo.PostRenderCameraUnderStereoRenderPos = c6.position;
            vrInfo.PostRenderCameraUnderStereoRenderRot = c6.rotation;
        }
    
        void saveToDrive()
        {
            string json = JsonUtility.ToJson(vrInfo);
            PlayerPrefs.SetString("vrInfo", json);
            PlayerPrefs.Save();
            Debug.Log(json);
            Debug.Log("Quit");
        }
    
    #if USEWITHSECENE
        void Update()
        {
            updateCamTransform();
        }
    
        void OnDisable()
        {
            saveToDrive();
        }
    #else
        //For iOS
    #if UNITY_IOS
        public void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                //Convert to Json and Save
                updateCamTransform();
                saveToDrive();
            }
        }
    #else
        //For Other Devices 
        public void OnApplicationQuit()
        {
            //Convert to Json and Save
            updateCamTransform();
            saveToDrive();
        }
    #endif
    #endif
    }
