    void validateDetails()
    	{
    		if (txt1Yes1.Enabled && txt1Yes2.Enabled)
    		{
    			if ((txt1Yes1.Text.Equals(string.Empty) || txt1Yes2.Text.Equals(string.Empty)))
    			{
    				MessageBox.Show("Please Enter All The Details");
    			}
    		}
    	}
