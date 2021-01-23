    private void tbInput_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
    {
        double dtemp;
        if (!double.TryParse(sender.Text, out dtemp) && sender.Text != "")
        {
            int pos = sender.SelectionStart - 1;
            sender.Text = sender.Text.Remove(pos, 1);
            sender.SelectionStart = pos;
        }
    }
