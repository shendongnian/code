    protected void gvProject_RowCommand(object sender, GridViewCommandEventArgs e)
       {
        int rowIndex, id;
        
        rowIndex = Convert.ToInt32(e.CommandArgument);
        GridView grid = (GridView)sender;
        
        if (e.CommandName == "DeleteProject" || e.CommandName == "AddFolder")
        {
        	id = Convert.ToInt32(grid.DataKeys[rowIndex].Value);
        
            ...    
        }
    }
