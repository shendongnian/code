    private void textbox1_TextChanged(object sender, EventArgs e)
    {
        EnableButton();
    }
    
    private void textbox2_TextChanged(object sender, EventArgs e)
    {
        EnableButton();
    }
    
    private void  EnableButton()
    {
        if(textbox1.Text == "" || textbox2.Text == "")
        {
            button1.Enabled = false;
            button2.Enabled = false;
        }
        else
        {
            button1.Enabled = true;
            button2.Enabled = true;
        }
    }
