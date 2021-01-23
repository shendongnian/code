    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        bool isError;
        DataDTO data = new DataDTO();
        BaseDAO connexion = new BaseDAO();
        try
        {
            foreach (GridViewRow row in this.GridView1.Rows)
            {
                // Perform operations here
            }
        }
        catch
        {
            MessageBox.Show("Some Error message>");
            isError=true;
        }
        if(!isError)
           MessageBox.Show("<success message>");  
       // Rest of process         
    }
