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
        }
        catch(Exception exc)
        {
            MessageBox.Show(exc.Message); //message from .NET
            //MessageBox.Show("your custom message"); // custom message.
            isError=true;
        }    
    }
