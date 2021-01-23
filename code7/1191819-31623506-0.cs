    Vector3 newRotationAngles = transform.rotation.eulerAngles;
    
    	if (Input.GetKey(KeyCode.LeftArrow)) {
    
    		newRotationAngles.z += 1;
    		
    	} else if (Input.GetKey(KeyCode.RightArrow)) {
    
    		newRotationAngles.z -= 1;
    	}
    
    	transform.rotation = Quaternion.Euler (newRotationAngles);
