    protected async override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        
        var messageDialog = new MessageDialog("Please pick a folder where you'd like to store your documents", "Choose storage");
        messageDialog.Commands.Clear();
        UICommand okCommand = new UICommand("Ok");
        messageDialog.Commands.Add(okCommand);
        var cmd = await messageDialog.ShowAsync();
        if (cmd == okCommand)
        {
            await PickFolder();
        }
    }
