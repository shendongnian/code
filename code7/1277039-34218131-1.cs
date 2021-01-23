    protected void CartList_RowDataBound(object sender, GridViewRowEventArgs e)
    { 
    LinkButton l = (LinkButton)e.Row.FindControl("DeleteRow"); 
    l.Attributes.Add("onclick", "javascript:return " +
    "confirm('Are you sure you want to delete this record " +
    DataBinder.Eval(e.Row.DataItem, "Item.Id") + "')");
    }
    protected void GridView1_RowCommand(object sender, 
                         GridViewCommandEventArgs e)
    {
     if (e.CommandName == "Delete")
     {
       // get the categoryID of the clicked row
      int categoryID = Convert.ToInt32(e.CommandArgument);
      // Delete the record 
      DeleteRecordByID(categoryID);
    // Implement this on your own :) 
    }
    }
