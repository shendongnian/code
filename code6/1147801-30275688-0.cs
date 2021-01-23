    using OrderByExtensions;
    public static IQueryable<T> OrderData<T>(IQueryable<T> data)
    {
        try
        {
            Order order = Order.ASC;
            var result = Enum.TryParse<Order>(_gridSettings.SortOrder, true, out order);
            var sortColumn = _gridSettings.IsSearch ? _gridSettings.SortColumn : _defaultColumn;
            data = data.OrderBy(sortColumn + " " + _gridSettings.SortOrder.ToString());
        }
        catch (Exception ex)
        {
            log.WriteLog(MethodBase.GetCurrentMethod(), LogLevel.FATAL, ex);
        }
        return data;
    }
