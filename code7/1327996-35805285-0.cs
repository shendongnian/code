    public static IOrderedEnumerable<Customer> OrderByCustomer(IEnumerable<Customer> enu, Column column)
    {
        Func<Customer, object> selector;
        if (!column.ColName.StartsWith("custom_"))
        {
            var propertyInfo = typeof(Customer).GetProperty(column.ColName);
            selector = x => propertyInfo.GetValue(x, null);
        }
        else
        {
            selector = x =>
            {
                object obj;
                ((IDictionary<string, object>)x.custom).TryGetValue(column.ColName.Substring("custom_".Length), out obj);
                return obj;
            };
        }
        IOrderedEnumerable<Customer> ordered = enu as IOrderedEnumerable<Customer>;
        if (ordered == null)
        {
            if (column.SortOrder == SortOrder.Asc)
            {
                return enu.OrderBy(selector);
            }
            else
            {
                return enu.OrderByDescending(selector);
            }
        }
        if (column.SortOrder == SortOrder.Asc)
        {
            return ordered.ThenBy(selector);
        }
        else
        {
            return ordered.ThenByDescending(selector);
        }
    }
