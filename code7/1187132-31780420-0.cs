    decimal value;
    if (direction == ListSortDirection.Ascending)
    {
        // check if element count is not 0 and value is decimal
        if (query.Count() > 0 &&
            decimal.TryParse(prop.GetValue(query.ElementAt<T>(0)).ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out value))
        {
            // convert to decimal and sort
            query = query.OrderBy(i => Convert.ToDecimal(prop.GetValue(i)));
        }
        else query = query.OrderBy(i => prop.GetValue(i));
    }
    else
    {
        if (query.Count() > 0 &&
            decimal.TryParse(prop.GetValue(query.ElementAt<T>(0)).ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out value))
        {
            query = query.OrderByDescending(i => Convert.ToDecimal(prop.GetValue(i)));
        }
        else query = query.OrderByDescending(i => prop.GetValue(i));
    }
