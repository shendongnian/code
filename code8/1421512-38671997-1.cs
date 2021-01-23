    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    	{
    		foreach (Control control in this.Controls)
    		{
    			if (control is TextBox)
    			{
    				TextBox tbox = control as TextBox;
    				if (checkBox1.Checked)
    				{
    					tbox.Enabled = false;
    				}
    				else
    					tbox.Enabled = true;
    			}
    		}
    	}
