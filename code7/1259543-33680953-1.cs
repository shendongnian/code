    private void buttonNUM_Click(object sender, EventArgs e)
    {
        if (SelectedTextBox != null)
        {
            (SelectedTextBox as TextBox).Text = buttonNUM.Text;//Or set it to the actual value, whatever.
        }
    }
