    protected override void OnResume()
	{
		base.OnResume();
		buttonAlert.Click += OnButtonClick;
	}
	protected override void OnPause()
	{
		base.OnPause();
		buttonAlert.Click -= OnButtonClick;
	}
    private void OnButtonClick(object sender, EventArgs e)
    {
        textChange.Text = string.Format("Hello World");
    }
