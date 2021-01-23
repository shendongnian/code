    public float angle;
    
    void Update() {
    	if ( Input.touches.Length > 0 && Input.GetTouch(0).phase == TouchPhase.Moved ) {
    		angle += Input.GetTouch(0).deltaPosition.y;
    		transform.rotation *= Quaternion.AngleAxis( angle, Vector3.forward );
    	}
    }
