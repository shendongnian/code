    IQueryable<area> filteredItems = db.areas.Where(x =>   x.Name.Contains(filter)));
    IQueryable<area> orderedItems;
    if (IsAscending)
    {
        orderedItems = filteredItems.OrderBy(item => typeof(area).GetProperty(colName).GetValue(item).ToString());
    }
    else
    {
        orderedItems = filteredItems.OrderByDescending(item => typeof(area).GetProperty(colName).GetValue(item).ToString());
    }
