    private void GenericTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
       e.Handled = !IsTextAllowed(e.Text, @"[^a-zA-Z]");
    }
    private static bool IsTextAllowed(string Text, string AllowedRegex)
    {
        try
        {
            var regex = new Regex(AllowedRegex);
            return !regex.IsMatch(Text);
        }
        catch
        {
            return true;
        }
    }
