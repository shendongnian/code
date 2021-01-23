    void FixedUpdate(){
			// Check to see if bounds left right
			if(transform.position.x < 0.25f && tranform.position.x > -0.3f){
				if (Input.GetKeyUp(KeyCode.RightArrow))
				{
					transform.position += new Vector3(playerSpeed, 0, 0);
				}    
				else if (Input.GetKeyUp(KeyCode.LeftArrow))
				{
					transform.position += new Vector3(-playerSpeed, 0, 0);
				}
			}
			// Check to see if bounds up and down
			if(transform.position.y < 0.15f && tranform.position.y > -0.1f){
				if (Input.GetKeyUp(KeyCode.UpArrow))
				{
					transform.position += new Vector3(0, playerSpeed, 0);
				}
				else if (Input.GetKeyUp(KeyCode.DownArrow))
				{
					transform.position += new Vector3(0, -playerSpeed, 0);
				}
			}
		}
