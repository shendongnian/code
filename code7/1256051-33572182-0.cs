	private bool isPageLoaded = false;
	private bool isButtonClicked = false;
	private void ButtonClick()
	{
        isButtonClicked = true;
		doTheFirstThing();
		if( isPageLoaded )
		{
		    doTheSecondThing();
		}
	}
	private void PageLoad()
	{
		isPageLoaded = true;
		if( isButtonClicked )
		{
		    doTheSecondThing();
		}
		// else let the button click handle the SecondThing()
	}
