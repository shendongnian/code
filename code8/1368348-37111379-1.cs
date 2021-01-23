    private void AutostartClick(object sender, EventArgs e)
    {
    .... Do some Code
    // Wait here
    while (waitvar != "go")
    {
	this.Invoke(new EventHandler(DisplayText));
    }
    .... Do some Code
    }
