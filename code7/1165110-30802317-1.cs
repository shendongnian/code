    public static Expression<Func<T, bool>> GetEqualExpression(string parameterName, 
        string comparisonValue)
    {
        var param = Expression.Parameter(typeof (T), parameterName);
        var prop = Expression.Property(param, parameterName);
        var propInfo = (PropertyInfo) Property.Member;
        var propType = propInfo.PropertyType;
        if (propType == typeof(DateTime))
        {
            const string dateFormat = "ddd MMM d yyyy HH:mm:ss 'GMT'K";
            var parsedDate = DateTime.ParseExact(comparisonValue, dateFormat, CultureInfo.InvariantCulture);
            var dayStart = new DateTime(parsedDate.Year, parsedDate.Month, parsedDate.Day, 0, 0, 0, 0);
            var dayEnd = new DateTime(parsedDate.Year, parsedDate.Month, parsedDate.Day, 23, 59, 59, 999);
        
            var left = Expression.Lambda<Func<T, bool>>(Expression.GreaterThanOrEqual(prop, Expression.Constant(dayStart)), param);
            var right = Expression.Lambda<Func<T, bool>>(Expression.LessThanOrEqual(prop, Expression.Constant(dayEnd)), param);
        
            return left.Compose(right, Expression.And);
        }
        ...
    }
