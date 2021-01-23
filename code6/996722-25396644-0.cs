    protected void GridView1_DataBound(object sender, GridViewRowEventArgs e)
     {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (condition)
            {
                  e.Row.Cells[0].CssClass = "red";
            }
         }
       }
