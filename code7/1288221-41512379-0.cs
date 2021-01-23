    private async Task<string> InputTextDialogAsync(string title)
    {
        TextBox inputTextBox = new TextBox();
        inputTextBox.AcceptsReturn = false;
        inputTextBox.Height = 32;
        ContentDialog dialog = new ContentDialog();
        dialog.Content = inputTextBox;
        dialog.Title = title;
        dialog.IsSecondaryButtonEnabled = true;
        dialog.PrimaryButtonText = "Ok";
        dialog.SecondaryButtonText = "Cancel";
        if (await dialog.ShowAsync() == ContentDialogResult.Primary)
            return inputTextBox.Text;
        else
            return "";
    }
