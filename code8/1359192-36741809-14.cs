	[Test]
	public void AppLaunches()
	{
	    app.Repl();
		app.WaitForElement(c => c.Marked("decor_content_parent"));
		app.Invoke("MyBackdoorMethod");
	}
