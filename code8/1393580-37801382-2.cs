    protected void btnUpdate_Click(object sender, EventArgs e)
    {       
        DataDTO data = new DataDTO();
        BaseDAO connexion = new BaseDAO();
        try
        {
            foreach (GridViewRow row in this.GridView1.Rows)
            {
                // Perform operations here
            }
           // show success message  
        }
        catch
        {
            // Show Some Error message
            isError=true;
        }
        // Rest of process         
    }
