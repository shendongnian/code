    protected void GridReport_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                
                if (item["ScanDate"].Text == "01/01/1900")
                {
                    item["ScanDate"].Text = "";
                }
                if(item["ScanTime"].Text == "12:00:00 AM")
                {
                    item["ScanTime"].Text = "";
                }
            }
       }
