    using UnityEngine;
    using System.Collections;
    public class PosFreezer : MonoBehaviour {
    
    	void Start () {
            var rb = GetComponent<Rigidbody>();
            //Modify the constraints directly.
            rb.constraints = RigidbodyConstraints.FreezePositionY;
    	}
    }
