    public Expression<Func<Product, bool>> GenerateProductExpression()
    {
        var param = Expression.Parameter(typeof(Product), "p");
        var nameValue = Expression.Constant("name_val");
        var valueValue = Expression.Constant("name_val");
        var specifications = Expression.Property(param, "Specifications");
        var body =
            Expression.Call(typeof(Enumerable), "Any", new[] { typeof(ProductSpecification) },
                specifications, GenerateAnyPredicate(nameValue, valueValue)
            );
        return Expression.Lambda<Func<Product, bool>>(body, param);
    }
    
    public Expression<Func<ProductSpecification, bool>> GenerateAnyPredicate(
            Expression nameValue, Expression valueValue)
    {
        var param = Expression.Parameter(typeof(ProductSpecification), "s");
        var name = Expression.Property(param, "Name");
        var value = Expression.Property(param, "Value");
        var body = Expression.AndAlso(
            Expression.Call(name, "Contains", null, nameValue),
            Expression.Call(value, "Contains", null, valueValue)
        );
        return Expression.Lambda<Func<ProductSpecification, bool>>(body, param);
    }
