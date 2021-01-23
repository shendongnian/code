    private void textBoxes_TextChanged(object sender, EventArgs e)
    {
        EnableButton();
    }
    
    
    private void EnableButton()
    {
        button1.Enabled = !Controls.OfType<TextBox>().Any(x => string.IsNullOrEmpty(x.Text));
    }
