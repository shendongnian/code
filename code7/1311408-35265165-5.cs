    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
         
               
                foreach (TableRow row in GridView1.Controls[0].Controls)
                {
                 if("your Condition")
                          {
                          row.Cells[0].Control[0].Visible = false;
                          }
                }        
        }
