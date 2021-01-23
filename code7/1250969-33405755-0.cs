	bool isCrosshair = false;
	private void OnGUI(){
		if (GUI.Button(new Rect(10, 10, 10, 10), "Fire!"))
		{
	        FireButtonClicked();
	    }
	}
	private void FireButtonClicked()
	{
		if(isCrosshair){
			//Fire!
		}
		isCrosshair = !isCrosshair;
	}
