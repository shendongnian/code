     protected void GridView1_RowCommand(object sender, 
      GridViewCommandEventArgs e)
    {
      if (e.CommandName == "edituser") /*if you need this
      {
        // Retrieve the row index stored in the 
        // CommandArgument property.
        int index = Convert.ToInt32(e.CommandArgument);
    
        // Retrieve the row that contains the buttonfrom the Rows collection.
        GridViewRow row = GridView1.Rows[index];
    
        // Add code here now you have the specific row data
      }
    
      }
