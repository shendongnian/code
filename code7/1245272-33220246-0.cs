    using UnityEngine;
    using System.Collections;
    public class IsTriggerLockCamera : MonoBehaviour {
    public static bool CameraLock = false;
    public void OnTriggerStay2D(Collider2D other) {
        CameraLock = true;
        Debug.Log ("Im inside"); 
    }
        public void OnTriggerExit2D(Collider2D other) {
        CameraLock = false;
        Debug.Log ("I exited");
    }
