    public static IEnumerable<T> Where<T>(this IEnumerable<T> source, string propName, object value)
    {
        var type = typeof(T);
                        
        var propInfo = type.GetProperty(propName,BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        var parameterExpr = Expression.Parameter( type, "x" ); //x
        var memberAccessExpr = Expression.MakeMemberAccess( parameterExpr, propInfo ); //x.Prop
        var lambda = Expression.Lambda( Expression.Equal(memberAccessExpr, Expression.Constant(value)), 
                                        parameterExpr );         //x=>x.Prop==value
        var mi = typeof(Enumerable)
                    .GetMethods()
                    .Where(m => m.Name == "Where")
                    .First(m => m.GetParameters().Count() == 2)
                    .MakeGenericMethod(type);
            
        return (IEnumerable<T>)mi.Invoke(null, new object[] { source, lambda.Compile() });
    }
