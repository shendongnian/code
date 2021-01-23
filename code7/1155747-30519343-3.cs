        protected void grid1_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRow row = (DataRow)e.Row.DataItem;
                    HyperLink hlView = (HyperLink)e.Row.FindControl("hlView");
                    LinkButton lbPrint = (LinkButton)e.Row.FindControl("lbPrint");
                    if (row != null && lbPrint != null && hlView != null)
                    {
                        hlView.NavigateUrl = "#Order" + row["orderId"];
                        lbPrint.OnClientClick = string.Format("printContent('Ticket{0}')", row["orderId"]);
                    }
                }
            }
