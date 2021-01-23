		 //Player Climbs Up One Block Heights But Dose Not Climb Anything Higher
		if ((PlayerClimAction.posOneHit == true) && (PlayerClimAction.posTwoHit == false))
			{
			// Moves the Player Up By 0.5
			controller.Move ((transform.up * (float) 0.5f)); 
			// Moves The Player Forward
			controller.Move (motion * Time.deltaTime); // Move Normaly
			// Reset Triggers
			PlayerClimAction.posOneHit = false;
			PlayerClimAction.posTwoHit = false;
		}else
		{
			controller.Move (motion * Time.deltaTime); // Move Normaly
		}
