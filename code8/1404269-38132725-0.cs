	private async void Button_Click(object sender, RoutedEventArgs e)
	{
		var signal = new SemaphoreSlim(0, 1);
		for (int i = 0; i < 10; i++)
		{
			var window = new Window();
			window.Closed += (s, _) => signal.Release();
			window.Show();
			await signal.WaitAsync();
		}
	}
