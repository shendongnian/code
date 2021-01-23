     protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
            {
              if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                    if("your Condition")
                      {
                      
                        e.Row.Cells[0].Control[0].Visible = false;//or true
                        }
                     }        
             }
    
     
