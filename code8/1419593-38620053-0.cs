    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
          if(e.Row.Cells[cellno]=="") 
           {
              e.Row.Cells[cellno].Text = msg1
           }
        }
    }
 
