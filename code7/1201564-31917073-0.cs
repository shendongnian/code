    private **async** void Button_Click(object sender, ...)
    {
        await LoadingDialog();
        SaveAndLoadData.SaveUserData(ApplicationData.UserData);
        MainWindowLogic.LogIntoWebsites();
    }
    private async void LoadingDialog()
    {
        var controller = await this.ShowProgressAsync("Logging In...", "");
    }
