    private async void AddressTextBox_Paste(object sender, TextControlPasteEventArgs e)
    {
        TextBox addressBox = sender as TextBox;
        if (addressBox != null)
        {
            // Mark the event as handled first. Otherwise, the
            // default paste action will happen, then the custom paste
            // action, and the user will see the text box content change.
            e.Handled = true;
    
            // Get content from the clipboard.
            var dataPackageView = Windows.ApplicationModel.DataTransfer.Clipboard.GetContent();
            if (dataPackageView.Contains(Windows.ApplicationModel.DataTransfer.StandardDataFormats.Text))
            {
                try
                {
                    var text = await dataPackageView.GetTextAsync();
                    
                    // Remove line breaks from multi-line text and
                    // replace with comma(,).
                    string singleLineText = text.Replace("\r\n", ", ");
    
                    // Replace any text currently in the text box.
                    addressBox.Text = singleLineText;
                }
                catch (Exception)
                {
                    // Ignore or handle exception as needed.
                }
            }
        }
    }
