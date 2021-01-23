	{
		Sprite myMenuButton = Resources.Load <Sprite> ("sprite_menu_to_load");
		// Cache the script
		MouseDownScript mouseScript = myMenuButton.GetComponent<MouseDownScript>();
		// Add anonymous actions with a lambda as such:
		mouseScript.Actions.Add(() => /*Any action here*/);
		// Add existing functions as such:
		mouseScript.Actions.Add(MouseDownAction));
	}
	public void MouseDownAction() {}
