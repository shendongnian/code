    foreach (DataControlField col in gvOrderItems.Columns)
    {
        if (col.SortExpression == sortExpression)
        {
          int index = gvOrderItems.Columns.IndexOf(col);
          gvOrderItems.Columns[index].HeaderStyle.CssClass = "descending"; 
        }
    }
