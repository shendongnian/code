    private bool IsPositive32BitInteger(String text)
    {
        if (text.Length <= 0 || (int)text[0] == 48) // Restricts empty strings and numbers with preceding 0's or 0 itself.
            return false;
        for (int i = 0; i < text.Length; i++)
        {
            var c = (int)text[i];
            if (c < 48 || c > 57) // Check that all characters are between 0 and 9.
                return false;
        }
        int result;
        return Int32.TryParse(text, out result);
    }
    private void CurrentPageNumber_TextChanged(object sender, TextChangedEventArgs e)
    {
        var textBox = (TextBox)sender;
        if (textBox.Text.Length <= 0)
        {
            textBox.Text = "1";
            return; // Set text to "1" as default and return. The event will fire again since we set the Text property.
        }
        if (textBox.Text.StartsWith("0"))
        {
            textBox.Text = textBox.Text.TrimStart(new char[] { '0' });
            return; // Set text to "1" as default and return. The event will fire again since we set the Text property.
        }
        if (!IsPositive32BitInteger(textBox.Text)) {
            textBox.Text = "1";
            return; // Set text to "1" as default and return. The event will fire again since we set the Text property.
        }
        // At this point the value is forced into the state you want and you can do other stuff.
    }
