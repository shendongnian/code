    using UnityEngine;
    using System.Collections;
    
    public class RotaionManager : MonoBehaviour {
    
    	// Motion start point
    	public Transform origin;
    	// Motion end point
    	public Transform destination;
    
    	// Start and en anle - 360 for single full rotation
    	public float startAngle = 0;
    	public float endAngle = 360;
    
    	void Update () {
    
    		// Distance to origin
    		var dstOrigin = Vector3.Distance(origin.position, transform.position);
    		// Distance to destination
    		var dstDestination = Vector3.Distance(destination.position, transform.position);
    		// Parameter
    		float t = (dstDestination + dstOrigin == 0 ? 0 : (dstOrigin / (dstDestination + dstOrigin) ) );
    		// The angle at current t
    		float angle = Mathf.Lerp(startAngle, endAngle, t);
    
    		// Rotate the object by the angle, then make sure it also faces destination
    		transform.rotation = Quaternion.LookRotation(destination.position - origin.position) * Quaternion.Euler(angle, 0, 0);
    
    	}
    }
