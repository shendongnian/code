    private async void secondBtn_Click(object sender, RoutedEventArgs e)
    {
        var box = new ContentDialog()
                {
                    Title = "File Name",
                    Content = fileName,
                    PrimaryButtonText = "Ok",
                    PrimaryButtonCommand = new RelayCommand(myAction),
                    SecondaryButtonText = "Cancel"
                };
        await box.ShowAsync();
    }
    private async void myAction()
    {
        await (new MessageDialog("User clicked ok")).ShowAsync();
    }
