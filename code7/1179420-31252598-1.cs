    private static Expression<Func<DAL.Faktura, bool>> beforeInclusiveExpression(Expression<Func<DAL.Faktura, DateTime?>> getDateTime, DateTime date)
    {
        // return f => getDateTime(f).HasValue && getDateTime(f).Value.Date <= date.Date;
        var parameterF = Expression.Parameter(typeof(DAL.Faktura), "f");                          // f
        var getDateTimeInvocation = Expression.Invoke(getDateTime, parameterF);                   // getDateTime(f)
        var getDateTime_HasValue = Expression.Property(getDateTimeInvocation, "HasValue");        // getDateTime(f).HasValue
        var getDateTime_Value = Expression.Property(getDateTimeInvocation, "Value");              // getDateTime(f).Value
        var getDateTime_Value_Date = Expression.Property(getDateTime_Value, "Date");              // getDateTime(f).Value.Date
     
        return Expression.Lambda<Func<DAL.Faktura, bool>>(Expression.AndAlso(getDateTime_HasValue,// getDateTime(f).HasValue &&
            Expression.LessThanOrEqual(getDateTime_Value_Date, Expression.Constant(date.Date))),  // getDateTime(f).Value.Date <= date.Date
            parameterF);                                                                          
    }
