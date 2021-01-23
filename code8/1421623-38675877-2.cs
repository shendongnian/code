    private void textBox1_TextChanged(object sender, EventArgs e)
    {  
        if (textbox.Text.Length > 0)
        {
            button1.Enabled = true;
        }
        else
            button1.Enabled = false;
    }
