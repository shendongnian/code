    // initialize queryOptions using a common query
    QueryOptions queryOptions = new QueryOptions(CommonFileQuery.DefaultQuery, fileTypeFilter);
            
    // clear all existing sorts
    queryOptions.SortOrder.Clear();
    // add descending sort by date modified
    SortEntry se = new SortEntry();
    se.PropertyName = "System.DateModified";
    se.AscendingOrder = false;            
    queryOptions.SortOrder.Add(se);
