    foreach (Control c in this.Controls)
    {
        if (c is TextBox)
        {
            TextBox textBox = c as TextBox;
            if (textBox.Text == string.Empty)//Compare if textbox is empty
            {
                // Text box is empty.
                // You COULD store information about this textbox is it's tag.
            }
        }
    }
