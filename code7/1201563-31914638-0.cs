	private async void Button_Click(object sender, RoutedEventArgs e)
	{
		await LoadingDialogAsync();
		SaveAndLoadData.SaveUserData(ApplicationData.UserData);
		MainWindowLogic.LogIntoWebsites();
	}
	private async Task LoadingDialogAsync()
	{
		var controller = await this.ShowProgressAsync("Logging In...", "");
	}
