    //Get current worldspace position of mouse cursor
		RaycastHit2D[] hits = Physics2D.LinecastAll(clickedPos,clickedPos,theLayer);
		// Copy Linecast to HashSet (unique records), clean out the "Background" GameObject
		foreach (RaycastHit2D arf2D in hits) {
			//linecast_GameObject = GameObject.FindWithTag(arf2D.collider.tag);
			linecast_GameObject = GameObject.Find(arf2D.collider.name);
			//if (linecast_GameObject.name != "Background") {
			if (linecast_GameObject.tag != "Background") {
				linecast_GameObject_HashSet.Add(linecast_GameObject);
				clickedOnTheBackground = false;
			}
			else if (hits.Length == 1) {
				clickedOnTheBackground = true;
				fingerSelection_GO = GameObject.FindWithTag("Dummy_GameObject");
				//fingerSelection_GO = GameObject.Find("Dummy_GameObject");
			}
		}
