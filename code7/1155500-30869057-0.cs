    void OnMouseOver ()
		{
        Vector2 mousePos;
		Vector3	mousePosWorld = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mousePos.x = mousePosWorld.x;
			mousePos.y = mousePosWorld.y;
			this.transform.position = Vector3.MoveTowards (transform.position, new Vector3 (mousePosWorld.x, mousePosWorld.y, 0), speed * Time.deltaTime);
						
		
			
			if (enableDrag) {
				
				Vector3 cursorPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0);
				Vector3 cursorPosition = Camera.main.ScreenToWorldPoint (cursorPoint) + offset;
				transform.position = new Vector3 (cursorPosition.x, cursorPosition.y, 0);
				
				
			}
    If void OnCollisionEnter2D (Collision2D coll)
    {
     if (coll.gameObject.tag == "Obstacle") 
     {
         enableDrag= false;
      }
    }
