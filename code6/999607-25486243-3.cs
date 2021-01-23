    private void Search(string searchText)
	{
		Task.Run(() =>
			{
				// Execute search
				Dispatcher.Invoke(() =>
				{
					if (searchText == searchBox.Text)
					{
                        // Result is good
					}
				});
		});
	}
