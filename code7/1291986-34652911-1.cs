    protected void grdUpdateData_SellsEdit(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName == "Edit")
        {   
            GridView grdUpdateData = (sender as GridView);
            int index = Convert.ToInt32(e.CommandArgument);	  
            GridViewRow row = grdUpdateData.Rows[index];	 
            int RowId = Convert.ToInt32((row.Cells[0].FindControl("lblId") as Label).Text);
        }
    }
	
