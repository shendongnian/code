    public textboxPergjigja_TextChanged(object sender, TextChangedEventArgs e)
    {
        // If the text box is not "empty", it will be enabled;
        // If the text is "empty", it will be disabled.
        butoniVerteto.Enabled = !string.IsNullOrWhiteSpace(textBoxPergjigja.Text));            
    }
