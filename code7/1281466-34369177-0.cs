    public  Func<IQueryable<Level>, IOrderedQueryable<Level>> GetOrderByFunc()
            {
                if (request == null)
                {
                    request = new OrderByRequest
                    {
                        IsAscending = true,
                        PropertyName = "Name"  // CreatedDate , LevelNo etc
                    };
                }
                if (string.IsNullOrWhiteSpace(request.PropertyName))
                {
                    request.PropertyName = "Name";
                }
                Tuple<Expression, Type> selector = GetSelector(new List<string>() {request.PropertyName});
                Type type = selector.Item2;
                Type[] argumentTypes = new[] { typeof(Level), type };
    
                var orderByMethod = typeof(Queryable).GetMethods()
                    .First(method => method.Name == "OrderBy"
                        && method.GetParameters().Count() == 2)
                        .MakeGenericMethod(argumentTypes);
                var orderByDescMethod = typeof(Queryable).GetMethods()
                    .First(method => method.Name == "OrderByDescending"
                        && method.GetParameters().Count() == 2)
                        .MakeGenericMethod(argumentTypes);
    
                if (request.IsAscending)
                    return query => (IOrderedQueryable<Level>)
                        orderByMethod.Invoke(null, new object[] {query, selector.Item1});
                else
                    return query => (IOrderedQueryable<Level>)
                        orderByDescMethod.Invoke(null, new object[] {query, selector.Item1});
            }
    
            private static Tuple<Expression, Type> GetSelector(IEnumerable<string> propertyNames)
            {
                var parameter = Expression.Parameter(typeof(Level));
                Expression body = parameter;
    
                foreach (var property in propertyNames)
                {
                    body = Expression.Property(body,
                        body.Type.GetProperty(property));
                }
    
                return Tuple.Create(Expression.Lambda(body, parameter) as Expression
                    , body.Type);
            }
