    public void enableAsRequired()
    {
    	if (comboBox.Text.equals("something"))
    	{
    		button1.Enabled = true;
    		button2.Enabled = true;
    		button3.Enabled = false;
    		...
    	}
    	else if (...) { ... }
    	else {...}
    }
