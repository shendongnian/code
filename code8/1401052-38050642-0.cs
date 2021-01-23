    private void YourTextBox_TextChanged(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(YourTextBox.Text))
            YourButton.Enabled = false;
        else
            YourButton.Enabled = true;
    }
