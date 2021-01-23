    private void ChangeToDoubleWhenLeave(object sender, EventArgs e)
    {
        var textBox = sender as TextBox;
        if (textBox != null)
        {
            double value;
            if (double.TryParse(textBox.Text, out value))
            {
                textBox.Text = value.ToString("F");
            }
        }
    }
