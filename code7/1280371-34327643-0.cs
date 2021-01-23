      protected void GridView_RowDataBound(Object sender, GridViewRowEventArgs e)
      {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
          // Fetching BoundField Value.
          double dbvalue =Convert.ToDouble(e.Row.Cells[ColumnNumber].Text);
          e.Row.Cells[ColumnNumber].Text = String.Format("{0:0.00}", dbvalue); 
        }
      }
