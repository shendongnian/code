	private void OnClosing(object sender, CancelEventArgs e)
	{
		MessageBoxResult result = MessageBox.Show("Really close?",  "Warning", MessageBoxButton.YesNo);
		if (result != MessageBoxResult.Yes)
		{
			e.Cancel = true;
		}
		bool shouldClose = ((MyViewModel) DataContext).TryClose(false);
		if(!shouldClose)
		{
			e.Cancel = true;
		}
	}
