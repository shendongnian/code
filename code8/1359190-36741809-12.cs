	[Test]
	public void AppLaunches()
	{
	    app.Repl();
		//app.Screenshot("First screen.");
		//Assert.IsTrue(true);
		app.WaitForElement(c => c.Marked("action_bar_overlay_layout"));
		app.Invoke("Test");
	}
