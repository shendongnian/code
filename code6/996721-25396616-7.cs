    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
         if (e.Row.RowType == DataControlRowType.DataRow)
         {
             int iText =  Convert.ToInt32(e.Row.Cells[4].Text);
             
             if (iText < 0)
                 e.Row.Cells[4].ForeColor = System.Drawing.Color.Blue;             
             else if (iText > 0 && iText < 4)             
                 e.Row.Cells[4].ForeColor = System.Drawing.Color.Green;
             else if (iText > 4)           
                 e.Row.Cells[4].ForeColor = System.Drawing.Color.Red;            
         }
    }
