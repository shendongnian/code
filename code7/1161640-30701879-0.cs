    private void GV_RowDataBound(object o, GridViewRowEventArgs e)
    {        
       // apply custom formatting to data cells
       if (e.Row.RowType == DataControlRowType.DataRow)
       {
           // set formatting for the category cell
           TableCell cell = e.Row.Cells[0];
           cell.Width = new Unit("120px");
           cell.Style["border-right"] = "2px solid #666666";
         
           // set formatting for value cells
           for(int i=1; i<e.Row.Cells.Count; i++)
           {
                cell = e.Row.Cells[i];
                // right-align each of the column cells after the first
                // and set the width
                cell.HorizontalAlign = HorizontalAlign.Right;
                cell.Width = new Unit("90px");
                // alternate background colors
                if (i % 2 == 1)
                      cell.BackColor 
                          =  System.Drawing.ColorTranslator.FromHtml("#EFEFEF");
                      // check value columns for a high enough value
                      // (value >= 8000) and apply special highlighting
                }                    
            }
            
            // apply custom formatting to the header cells
            if (e.Row.RowType == DataControlRowType.Header)
            {
                foreach (TableCell cell in e.Row.Cells)
                {
                    cell.Style["border-bottom"] = "2px solid #666666";
                    cell.BackColor=System.Drawing.Color.LightGray;
                }
            }
            
        }
    }
