    protected void cartGrid_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.Footer)
                {
    
                    TableRow tableRow = new TableRow();
                    TableCell cell1 = new TableCell();
                    cell1.Text = "Add your your content here"; 
                    cell1.ColumnSpan = 8; // You can change this. If you want different cells you can add as many cells as you need
                    tableRow.Controls.Add(cell1);
                    e.Row.NamingContainer.Controls.Add(tableRow);
                    // You can add additional rows like this.
                }
            }
