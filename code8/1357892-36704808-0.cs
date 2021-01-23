    public static Expression<Func<T,bool>> RangeExpression<T>(string property1,string property2, IEnumerable<Range<DateTime>> criterias )
    {
                Expression result = null;
                ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "o");
                foreach (var item in criterias)
                {
                    var value1 = item.Start.Date;
                    var value2 = item.End.Date.AddDays(1);
    
                    MemberExpression memberExpression1 = Expression.PropertyOrField(parameterExpression, property1);
                    MemberExpression memberExpression2 = Expression.PropertyOrField(parameterExpression, property2);
    
                    ConstantExpression valueExpression1 = Expression.Constant(value1, typeof(DateTime));
                    ConstantExpression valueExpression2 = Expression.Constant(value2, typeof(DateTime));
    
                    BinaryExpression binaryExpression1 = Expression.GreaterThanOrEqual(memberExpression1, valueExpression1);
                    BinaryExpression binaryExpression2 = Expression.LessThan(memberExpression2, valueExpression2);
    
                    var ret1 = Expression.Lambda<Func<T, bool>>(binaryExpression1, parameterExpression);
                    var ret2 = Expression.Lambda<Func<T, bool>>(binaryExpression2, parameterExpression);
    
                    Expression and = Expression.And(ret1, ret2);
    
                    result = result!=null?Expression.OrElse(result, and):and;   
                }
                return Expression.Lambda < Func<T,bool>>(result, parameterExpression);
    }
