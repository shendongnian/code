	private async void Button_Click(object sender, RoutedEventArgs e)
	{
		await Task.Run(Test);
		CallBack();
	}
	private void Callback()
	{
		txtResult.Text = "Done!"
	}
	
	private void Test()
	{
		Thread.Sleep(3000); //long running operation, not necessarily pause
	}
