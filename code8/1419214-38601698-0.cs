    void Update(){
    
    		if (Input.GetKeyDown (KeyCode.Escape)) {
    
    			if (Cursor.lockState != CursorLockMode.Confined) {
    
    			Cursor.lockState = CursorLockMode.None;
    			Cursor.lockState = CursorLockMode.Confined;
    			Cursor.visible = true;
    			}
    		}
    	}
