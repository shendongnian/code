    public static IEnumerable<string> GetPropertiesName<TObj, TProp>(Expression<Func<TObj, TProp[]>> prop)
    {
        var array = (prop.Body as NewArrayExpression);
        var exp = array == null ? null : array.Expressions;
    
        if (exp != null)
        {
            //var expArr = (prop.Body as NewArrayExpression).Expressions;
    
            foreach (var oneProp in exp)
            {
                Expression onePropExp;
                if (oneProp.GetType() == typeof (UnaryExpression))
                {
                    onePropExp = (oneProp as UnaryExpression).Operand;
                }
                else
                {
                    onePropExp = oneProp;
                }
                var property = (onePropExp as MemberExpression).Member as PropertyInfo;
    
                if (property != null)
                {
                    yield return property.Name;
                }
                yield return string.Empty;
            }
    
        }
        yield return string.Empty;
    }
