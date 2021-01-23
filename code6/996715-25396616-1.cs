    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
         if (e.Row.RowType == DataControlRowType.DataRow)
         {
             int iTextLen =  e.Row.Cells[0].Text.Length;
             
             if (iTextLen < 0)
                 e.Row.Cells[0].ForeColor = System.Drawing.Color.Blue;             
             else if (iTextLen > 0 && iTextLen < 4)             
                 e.Row.Cells[0].ForeColor = System.Drawing.Color.Green;
             else if (iTextLen > 4)           
                 e.Row.Cells[0].ForeColor = System.Drawing.Color.Red;            
         }
    }
