	private async void btn_mods_Click(object sender, RoutedEventArgs e)
	{
		if (!IsServiceIsUp())
			return;
			
		function_buttons_stackpanel.IsEnabled = false;
		Loading();
		await Task.Run(() => 
		{
			var result = JsonConvert.DeserializeObject(_webServiceResponse);
			Console.Write(result.webServiceBaseUrl);
		});
		
		FinishedLoading();
		function_buttons_stackpanel.IsEnabled = true;
	}
	
