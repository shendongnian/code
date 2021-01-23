    private void textBox1_TextChanged(object sender, EventArgs e)
    {
    	TextBox s = (TextBox)sender;
    
    	listBox1.Items.Clear();
    
    	foreach (string value in listBoxItems)
    	{
    		if (value.IndexOf(s.Text, StringComparison.OrdinalIgnoreCase) >= 0)
    		{
    			listBox1.Items.Add(value);
    		}
    	}
    }
