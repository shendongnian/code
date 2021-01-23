     protected void gridview_OnRowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (e.Row.RowIndex % 2 != 0)
                    {
                        // or do whatever you what with your odd rows
                    }
                    else
                    {
                        // or do whatever you what with your Even rows
                    }
                }
            }
