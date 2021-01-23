     public static List<T> FullTextSearch<T>(this List<T> list, string searchKey)
            {
                ParameterExpression parameter = Expression.Parameter(typeof(T), "c");
                MethodInfo containsMethod = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });
                var publicProperties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                    .Where(p => p.PropertyType == typeof(string));
                Expression orExpressions = null;
    
                foreach (var callContainsMethod in from property in publicProperties
                                                                    let myProperty = Expression.Property(parameter, property.Name)
                                                                    let myExpression = Expression.Call(myProperty, "Contains", null, Expression.Constant(searchKey))
                                                                    let myNullExp = Expression.Call(typeof(string), (typeof(string).GetMethod("IsNullOrEmpty")).Name, null, myProperty)
                                                                    let myNotExp = Expression.Not(myNullExp)
                                                                    select new { myExpression, myNotExp })
                {
                    var andAlso = Expression.AndAlso(callContainsMethod.myNotExp, callContainsMethod.myExpression);
                    if (orExpressions == null)
                    {
                        orExpressions = andAlso;
                    }
                    else
                    {
                        orExpressions = Expression.Or(orExpressions, andAlso);
                    }
                }
    
                IQueryable<T> queryable = list.AsQueryable<T>();
                MethodCallExpression whereCallExpression = Expression.Call(
                    typeof(Queryable),
                    "Where",
                    new Type[] { queryable.ElementType },
                    queryable.Expression,
                    Expression.Lambda<Func<T, bool>>(orExpressions, new ParameterExpression[] { parameter }));
                var results = queryable.Provider.CreateQuery<T>(whereCallExpression).ToList();
                return results;
            }
