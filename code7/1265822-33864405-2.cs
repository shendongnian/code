     protected void GDVReports_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    foreach (TableCell cell in e.Row.Cells)
                    {
                        LinkButton linkButton = new LinkButton();
                        linkButton.Click += ViewDetails;
                        linkButton.Text= "Test"
                        cell.Controls.Add(linkButton);
                    }
                }
            }
