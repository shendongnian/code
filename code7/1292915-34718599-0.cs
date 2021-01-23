    using UnityEngine;
    using System.Collections;
    
    
    public class GetTransform : MonoBehaviour
    {
    	
    	public enum BradBodyBones
    	{
    		JtPelvis = 0,
    		JtSkullA = 1,
    		JtSkullB = 2
    		// more here later ...
    	}
    
    
    	void Start()
    	{
    		// Debug.Log(BradBodyBones.JtSkullA);  // JtSkullA  which is a string!
    		// Debug.Log((int)(BradBodyBones.JtSkullA));  // 1  which is an integer!
    
    		// GameObject Pelvis = GameObject.Find("JtPelvis");
    		// Debug.Log(Pelvis.transform.position.x);
    
    		Debug.Log(GetEnumTransform(BradBodyBones.JtPelvis).position.x);
    		Debug.Log(GetEnumTransform(BradBodyBones.JtPelvis).position.y);
    		Debug.Log(GetEnumTransform(BradBodyBones.JtPelvis).position.z);
    	}
    
    
    	Transform GetEnumTransform(BradBodyBones boneName)
    	{
    		Transform tmpTransf;
    		GameObject enumObject = GameObject.Find(boneName.ToString()); // GameObject.Find(boneName.ToString()).GetComponentInChildren<BradBodyBones>();
    		tmpTransf = enumObject.transform;
    		return tmpTransf;
    	}
    }
