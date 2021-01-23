    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class AlignCyl : MonoBehaviour {
    
    
    	GameObject cubeStart;
    	GameObject cubeEnd;
    	GameObject cylinder;
    
    	Vector3 endV; 
    	Vector3 startV;
    	Vector3 rotAxisV;
    	Vector3 dirV;
    	Vector3 cylDefaultOrientation = new Vector3(0,1,0);
    	
    	float dist;
    	
    	// Use this for initialization
    	void Start () {
    		
    		 cubeStart = GameObject.Find("CubeStart");
    		 cubeEnd   = GameObject.Find("CubeEnd");
    		
      		 cylinder  = GameObject.Find("Cylinder");
    		
    		endV   = cubeEnd.transform.position;
    		startV = cubeStart.transform.position;
    		
    		
    	}
    	
    	// Update is called once per frame
    	void Update () {
    		
    		// Position
    		cylinder.transform.position = (endV + startV)/2.0F;
    		
    		// Rotation
    		dirV = Vector3.Normalize(endV - startV);
    		
    		rotAxisV = dirV + cylDefaultOrientation;
    		
    		rotAxisV = Vector3.Normalize(rotAxisV);
    	
    		cylinder.transform.rotation = new Quaternion(rotAxisV.x, rotAxisV.y, rotAxisV.z, 0);
    
    		// Scale		
    		dist = Vector3.Distance(endV, startV);
    						
    		cylinder.transform.localScale = new Vector3(1, dist/2, 1);
    		
    	}
    }
