    using UnityEngine;
    using System.Collections;
    
    public class PixelPerfectCamera : MonoBehaviour {
    
        public static float PixelsToUnits = 1f;
        public static float scale = 1f;
       
        public Vector2 nativeResolution = new Vector2(400, 160);
        public Camera camera;
    
        void Awake()
        {
            if (camera.orthographic)
            {
                scale = Screen.height / nativeResolution.y;
                PixelsToUnits *= scale;
                camera.orthographicSize = (Screen.height / 2.0f) / PixelsToUnits;
            }
        }
    }
