    public List<T> OrderingList<T>(List<T> list, DataTablesParam model)
    {
        var iColumn = model.Order.FirstOrDefault().Column;
        var property = typeof(T).GetProperty(model.Columns.ToArray()[iColumn].Data);
        var param = Expression.Parameter(typeof(T), "p");
        Expression final = Expression.Property(param, property);
        // Boxing of value types
        if (property.PropertyType.IsValueType) {
            final = Expression.MakeUnary(ExpressionType.Convert, final, typeof(object));
        }
        var isDirAsc = model.Order.FirstOrDefault().Dir.Equals("asc");
        //                                     VVVVVV
        var lambda = Expression.Lambda<Func<T, object>>(final, param).Compile();
        return isDirAsc
            ? list.OrderBy(lambda).ToList()
            : list.OrderByDescending(lambda).ToList();
    }
