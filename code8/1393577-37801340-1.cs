    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        DataDTO data = new DataDTO();
        BaseDAO connexion = new BaseDAO();
        bool success = true;
    
        foreach (GridViewRow row in this.GridView1.Rows)
        {
            data.lblId = ((Label)row.FindControl("lblId")).Text;
    
    
            try
            {
                connexion.update_database(data);
            }
            catch
            {
                // Display error message and break loop
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('<success message>')", true);
                success = false;
                break;
            }
        }
    
        GridView1.EditIndex = -1;
        LoadGrid();
        // Display success message
        if (success)
        {
           ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('<success message>')", true);
        }
    }
