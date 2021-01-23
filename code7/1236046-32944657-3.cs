    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
            // The RowIndex of the Row where LinkButton was clicked
            int rowIndex = Convert.ToInt32(e.CommandArgument);
     
            // Get the GridView Row
            GridViewRow row = GridView1.Rows[rowIndex];
            
            // Read the Column values
            // e.g. for BoundFields use row.Cells[] 
            string Column_1_Value = row.Cells[0].Text;
            
            // for Columns defined using <itemTemplate> etc...
            // row.FindControl("<Control_ID>")
            string firstName = (row.FindControl("txtFirstName") as TextBox).Text;
    }
