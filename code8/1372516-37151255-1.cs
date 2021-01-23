    private void tagBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
    	// Allow max 10 tags in the tag box
    	string tags = tagBox.Text;
    	int count = tags.Split(',').Length - 1;
    	if (count > 9 && e.KeyChar == ',')
    	{
    		e.Handled = true;
    		MessageBox.Show("Max 10 tags are allowed.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    	}
    	else		
    		e.Handled = false;
    }
