    protected void GrdDataEdit_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "updateData")
        {
            // This will give you the ID of the record you are passing in the CommandArgument='<%# Eval("ID") %>'  
            int i = Convert.ToInt32(e.CommandArgument); 
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            TextBox price = (TextBox)row.FindControl("TxtPriceEdit");
        }
    }
