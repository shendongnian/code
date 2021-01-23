    if (QueryHelper.PropertyExists<Club>(orderByField))
    {
       query = query.OrderByProperty(SortOrder.Ascending, orderByField);
    }
    
    public enum SortOrder
    {
        Ascending,
        Descending,
    }
