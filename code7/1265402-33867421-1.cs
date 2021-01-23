    void GridView1_RowCommand(Object sender, GridViewCommandEventArgs e)
      {
        if(e.CommandName=="Select")
        {
          // Convert the row index stored in the CommandArgument
          // property to an Integer.
          int _rowIndex = Convert.ToInt32(e.CommandArgument);    
    
          GridViewRow selectedRow = CustomersGridView.Rows[_rowIndex];  
          string cellText = selectedRow.Cells[2].Text;  
        }
      }
