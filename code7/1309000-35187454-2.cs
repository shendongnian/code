    private void tbInput_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
    {
        if (!Regex.IsMatch(sender.Text, "^\\d*\\.?\\d*$") && sender.Text != "")
        {
            int pos = sender.SelectionStart - 1;
            sender.Text = sender.Text.Remove(pos, 1);
            sender.SelectionStart = pos;
        }
    }
