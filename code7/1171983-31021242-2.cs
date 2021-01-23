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
