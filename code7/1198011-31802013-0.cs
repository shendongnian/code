    var props = GetAllProperties<Bike>()
                .Except(new[] { GetProperty<Bike>(x => x.BikeColour) });
    Draw(bike, props);
----
    public IEnumerable<PropertyInfo> GetAllProperties<T>()
    {
        return typeof(T).GetProperties();
    }
    public PropertyInfo GetProperty<T>(Expression<Func<T,object>> expr)
    {
        var uExpr = expr.Body as UnaryExpression;
        var memberExpr = uExpr.Operand as MemberExpression;
        return memberExpr.Member as PropertyInfo;
    }
    void Draw(Bike b, IEnumerable<PropertyInfo> properties)
    {
    }
