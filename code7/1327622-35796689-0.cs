    private void Window_Loaded(object sender, RoutedEventArgs e)
	{
        // Set the width and height values to the values of working area
		this.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
		this.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
        // Move the window to top left corner of the screen
		this.Left = 0;
		this.Top = 0;	
	}
