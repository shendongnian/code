    protected void rptBillHeaders_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptLineItems = ((Repeater)item.FindControl("rptLineItems"));
                rptLineItems.DataSource = currentBill.LineItemsByVersion[rowNumber].Sort(BillLineItem.SortColumn.LineItemNumber, System.Data.SqlClient.SortOrder.Ascending);
                rptLineItems.DataBind();
                var DocColumn = (HtmlTableCell)e.Item.FindControl("DocColumn");
                if (lit.ObjectType.C == "C")
                {
                    if (DocColumn != null)
                    {
                        DocColumn.Visible = false;
                        DocHeader.Visible = false;
                    }
                }
                rowNumber++;
            }
        }
