    using UnityEngine;
    using System.Collections;
    using System.Runtime.InteropServices;
    
    public class GetImage {
    
        #if UNITY_WEBGL
    
            [DllImport("__Internal")]
            private static extern void getImageFromBrowser(string objectName, string callbackFuncName);
    
        #endif
    
        static public void GetImageFromUserAsync(string objectName, string callbackFuncName)
        {
            #if UNITY_WEBGL
    
                getImageFromBrowser(objectName, callbackFuncName);
    
            #else
    
                Debug.LogError("Not implemented in this platform");
    
            #endif
        }
    }
