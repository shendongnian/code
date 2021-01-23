    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        DataDTO data = new DataDTO();
        BaseDAO connexion = new BaseDAO();
    	try
    	{
    		foreach (GridViewRow row in this.GridView1.Rows)
    		{
    			data.lblId = ((Label)row.FindControl("lblId")).Text;
                connexion.update_database(data);
    		}
    
    		GridView1.EditIndex = -1;
    		LoadGrid();
    		// Display success message
            // Success Alert
    		ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Update Successfully')", true);
    	}
    	catch
    	{
    		// Display error message and break loop
            // Error Alert
    		ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Update Failed')", true);
    	}
    }
