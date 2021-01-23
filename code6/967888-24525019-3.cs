    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "updateData")
        {
            //int i = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
    
            TextBox tb = (TextBox)row.FindControl("asptxtsingleg");
        }
    }
