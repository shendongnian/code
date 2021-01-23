    private void textBox2_TextChanged(object sender, EventArgs e)
    {
        button6.Enabled = 
        	!String.IsNullOrEmpty(textBox2.Text) && textBox2.Text.Length > 5
    }
