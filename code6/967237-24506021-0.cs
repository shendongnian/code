            protected void AdminSearchGridView_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    TableRow tableRow = new TableRow();
                    TableCell cell1 = new TableCell();
                    cell1.Text = "Add your summary here"; // Get the calculation from database and display here
                    cell1.ColumnSpan = 5; // You can change this
                    tableRow.Controls.Add(cell1);
                    e.Row.NamingContainer.Controls.Add(tableRow);
                    // You can add additional rows like this.
                }
            }
