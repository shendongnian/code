    var parameterItem = Expression.Parameter(typeof(Item), "item");
    var lambda = Expression.Lambda<Func<Item, bool>>(
        Expression.Equal(
            Expression.Property(
                Expression.Property(
                    parameterItem, 
                    "Data"
                ), 
                "Name"
            ), 
            Expression.Constant("Soap")
        ), 
        parameterItem
    );
    var result = queryableData.Where(lambda);
