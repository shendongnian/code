    using UnityEngine;
    using System.Collections;
    
    public class PosFreezer : MonoBehaviour {
    
    	void Start () {
            var rb = GetComponent<Rigidbody>();
            var constr = rb.constraints; //grab a copy (NOT a reference)
            constr = RigidbodyConstraints.FreezePositionY; //(modify the copy)
    	}
    }
