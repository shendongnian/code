    using UnityEngine.Networking;
    public class Player : NetworkBehaviour
    {
        public Camera camera;
        
        void Awake()
        {
            if(!isLocalPlayer)
            {
                camera.enabled = false;
            }
        }
    }
