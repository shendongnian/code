    private void textbox1_Change(object sender, EventArgs e)
    {
        ConditionallyEnableSubmitButton();
    }
    
    private void textbox2_Change(object sender, EventArgs e)
    {
        ConditionallyEnableSubmitButton();
    }
    
    private void ConditionallyEnableSubmitButton()
    {
        button1.Enabled = (!string.IsNullOrWhiteSpace(textBox1.Text) ||   
                           !string.IsNullOrWhiteSpace(textBox2.Text));
    }
