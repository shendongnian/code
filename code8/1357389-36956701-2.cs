    private void WindowViewBase_ContentRendered(object sender, EventArgs e)
	{
	 if (IsContentRendered)
		{
			if (splashScreen != null)
			 splashScreen.Close();
			WindowState = WindowState.Maximized;
			Activate();
		}
	}
