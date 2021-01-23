    private async void MessageDialog_Click(object sender, RoutedEventArgs e)
    {
        var messageDialog = new MessageDialog("MessageDialog Test");
    
        await messageDialog.ShowAsync();
    }
    
    private async void ContentDialog_Click(object sender, RoutedEventArgs e)
    {
        var contentDialog = new ContentDialog()
        {
            Title = "ContentDialog Test",
            Content = "This is ContentDialog Test",
            PrimaryButtonText = "Ok"
        };
    
        await contentDialog.ShowAsync();
    }
