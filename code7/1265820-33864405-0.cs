    protected void GDVReports_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (TableCell cell in e.Row.Cells)
                {
                    HyperLink myLink = new HyperLink();
                    myLink.NavigateUrl = "ExitInt_DashBoard.aspx";
                    if (cell.Controls.Count > 0)
                    {
                        while (cell.Controls.Count > 0)
                        {
                            myLink.Click += ViewDetails;
                            myLink.Controls.Add(cell.Controls[0]);
                        }
                    }
                    else
                    {
                        myLink.Text = cell.Text;
                    }
                    cell.Controls.Add(myLink);
                }
            }
        }
