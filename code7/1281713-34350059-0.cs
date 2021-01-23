	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Vector2 mousePosition = new Vector2();
			mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	
			
			if(this.collider2D.OverlapPoint(mousePosition)){
				LoadScript();
			 
			}
	}
