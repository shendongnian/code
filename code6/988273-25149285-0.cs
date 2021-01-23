    void RowCommand(Object sender, GridViewCommandEventArgs e)
    { 
        int rowindex = Convert.ToInt32(e.CommandArgument);
        
        if (e.CommandName == "Update")
        {
          ....
        }
        if (e.CommandName == "Cancel")
        {
          ....
        }
    }
