	[Test]
	public void InvokeBackdoor()
	{
		// Wait for the Activity to load
		app.WaitForElement(c => c.Marked("decor_content_parent"));
		// Invoke the backdoor method MainActivity.MyBackDoorMethod
		app.Invoke("MyBackdoorMethod");
	}
