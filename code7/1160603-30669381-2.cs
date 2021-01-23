    void listView_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            currentItemIndex++;
            ListViewDataItem dataitem = (ListViewDataItem)e.Item;
            HtmlTableRow trControl = (HtmlTableRow)e.Item.FindControl("MainTableRow");
            if (IsOdd(currentItemIndex))
                trControl.BgColor = "DarkGray";
        }
    }
    private bool IsOdd(int value)
    {
        return value % 2 != 0;
    }
