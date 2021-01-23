	public form1() 
	{
			//You probably do this in a loop over all your buttons
			button1.Click += MyButtonClickHandler;
	}
	 
	private void MyButtonClickHandler(object sender, EventArgs e)
	{
		Button ClickedButton = (Button)sender;
		ClickedButton.ForeColor = Color.Red;
	}
