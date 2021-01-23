            protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
         {
             if (e.Row.RowType == DataControlRowType.DataRow)
             {
              
               
                 if (e.Row.Cells[8].Text == "Accepted")//orderstatus index
                 {
                  
                     e.Row.Enabled = false;
                 }
                 else
                 {
                    e.Row.Enabled = true;
                 }
             }
         }
