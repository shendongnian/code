    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
         
                //Just changed the index of cells based on your requirements
                foreach (TableRow row in GridView1.Controls[0].Controls)
                {
                 if("your Condition")
                          {
                          row.Cells[0].Control[0].Visible = false;
                          }
                }        
        }
