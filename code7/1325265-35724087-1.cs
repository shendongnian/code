	private async void Button_Click(object sender, RoutedEventArgs e)
	{
		await TestAsync();
		txtResult.Text = "Done!";
	}
	
	private async Task<int> TestAsync()
	{
		await Task.Delay(3000);
		return 0;
	}
	
