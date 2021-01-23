    private void txtbox1_KeyPress(object sender, KeyPressEventArgs e)
    {
    	if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) 
    	{
    		e.Handled = true;
    	}
    }
