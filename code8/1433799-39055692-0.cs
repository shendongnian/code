    private async void HardwareButtons_BackPresseed(object sender, BackPressedEventArgs e)
    {
        e.Handled = true;
        var dialog = new MessageDialog("Do you want exit?");
        dialog.Commands.Add(new Windows.UI.Popups.UICommand("yes") { Id = 0 });
        dialog.Commands.Add(new Windows.UI.Popups.UICommand("no") { Id = 1 });
        dialog.DefaultCommandIndex = 0;
        dialog.CancelCommandIndex = 1;
        var result = await dialog.ShowAsync();
        if (result.Label == "yes")
        {
            // Leaving this page. Stop listening for Back button presses.
            Windows.Phone.UI.Input.HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
            this.Frame.Navigate(typeof(BlankPage1));
            ((Frame)Window.Current.Content).BackStack.Clear();
        }
