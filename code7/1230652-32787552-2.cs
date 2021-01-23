    private async void GamePage_BackRequested(object sender, BackRequestedEventArgs e)
            {
                e.handled = true;
                var dialog = new Windows.UI.Popups.MessageDialog("Are you sure ?");
    
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Yes"));
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("No"));
    
            var result = await dialog.ShowAsync();
        }
