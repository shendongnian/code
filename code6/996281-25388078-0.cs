    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem dataItem = (GridDataItem)e.Item;
            string originalText = dataItem["ApplicationSSN"].Text;
            dataItem["ApplicationSSN"].Text = originalText.Substring(0, 3) + "-" + originalText.Substring(3, 2) + "-" + originalText.Substring(5, 4);
        }
    }
