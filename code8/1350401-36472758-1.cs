    private void txtCityInput_Leave(object sender, EventArgs e)
    {
    	do
    	{
    		if (txtCityInput.Text.Length == 0)
    		{
    			txtCityInput.Focus();
    			MessageBox.Show("Enter a City");
    		}
    		else
    		{
    			break;
    		}
    	}
    	while (!txtCityInput.Focused); 
    }
