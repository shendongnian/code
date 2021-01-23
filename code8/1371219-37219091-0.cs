    protected void RadGrid_ItemDataBound(object sender, GridItemEventArgs e)
    {
     if (e.Item is GridDataItem)
     {
      GridDataItem gridItem = e.Item as GridDataItem;
      dynamic dataItem = (YourType)(gridItem.DataItem);
      gridItem.ToolTip = dataItem.ID + " - " + dataItem.UUID;
     }
    }
