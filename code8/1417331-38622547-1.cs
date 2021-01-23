    using UnityEngine;
    using System.Collections;
    
    public class LocationServiceManager
    {
    
        AndroidJavaClass unityClass;
        AndroidJavaObject unityActivity;
        AndroidJavaObject unityContext;
        AndroidJavaClass customClass;
    
        public LocationServiceManager()
        {
            //Replace with your full package name
            sendContextReference("com.progammer.plugin.LocationService");
        }
    
        public void sendContextReference(string packageName)
        {
            unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            unityActivity = unityClass.GetStatic<AndroidJavaObject>("currentActivity");
            unityContext = unityActivity.Call<AndroidJavaObject>("getApplicationContext");
    
            customClass = new AndroidJavaClass(packageName);
            customClass.CallStatic("receiveContextInstance", unityContext);
        }
    
        ///////////////////////////////////MAIN FUNCTIONS/////////////////////////////////////
        public bool isLocationServiceEnabled()
        {
            return customClass.CallStatic<bool>("isLocationServiceEnabled");
        }
    
        public bool isGPSLocationServiceEnabled()
        {
            return customClass.CallStatic<bool>("isGPSLocationServiceEnabled");
        }
    
        public bool isNetworkLocationServiceEnabled()
        {
            return customClass.CallStatic<bool>("isNetworkLocationServiceEnabled");
        }
    
        public bool isAirplaneModeOn()
        {
            return customClass.CallStatic<bool>("isAirplaneModeOn");
        }
    
        public void notifyUserToEnableLocationService()
        {
            customClass.CallStatic("notifyUserToEnableLocationService");
        }
    }
