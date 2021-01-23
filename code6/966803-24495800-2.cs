        protected void GridView1_Sorting(object server, GridViewSortEventArgs e)
        {
            string strSortExpression = e.SortExpression;
            switch (strSortExpression)
            {
                case "FileName":
                case "FileDate":
                    if (e.SortExpression == (string)ViewState["SortColumn"])
                    {
                        // We are resorting the same column, so flip the sort direction
                        e.SortDirection =
                            ((SortDirection)ViewState["SortColumnDirection"] == SortDirection.Ascending) ?
                            SortDirection.Descending : SortDirection.Ascending;
                    }
                    Sort((IList<ListItem>)Session["fileData"], e.SortDirection);
                    ViewState["SortColumn"] = e.SortExpression;
                    ViewState["SortColumnDirection"] = e.SortDirection;
                break;
            }
        }
