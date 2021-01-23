    using UnityEngine;
    using System.Collections;
    public class Compass : MonoBehaviour {
	    void Update () {
		transform.localRotation = Quaternion.Euler(0, 360-transform.root.rotation.eulerAngles.y, 0);
	     }
    }
