     using UnityEngine;
    using System.Collections;
    
    public class Drag : MonoBehaviour {
    
    	private Vector3 offset = Vector3.zero;
    
    	void OnMouseDown () {
    		Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    		worldPos.z = transform.position.z;
    		offset = worldPos - transform.position;
    	}
    
    
    	void OnMouseDrag () {
    		Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    		worldPos.z = transform.position.z;
    		worldPos = worldPos - offset;
    		transform.position = worldPos;
    	}
    
    
    	void OnMouseUp () {
    		offset = Vector3.zero;
    	}
    
    }
