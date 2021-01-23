    protected void gvTransValues_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    	if (e.CommandName == "Editing")
    	{
    		int index = Convert.ToInt32(e.CommandArgument);
    		GridViewRow row = gvTransValues.Rows[index];
    
    		//do whatever you need here
    
    		modppOpen.Show();
    	}
    }
    	
