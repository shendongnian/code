    LambdaExpression BuildExpression(Type rootType, string propertyName)
        {
            try
            {
                var properties = propertyName.Split('.');
                ParameterExpression arg = Expression.Parameter(rootType, "x");
                Expression expr = arg;
                foreach (string property in properties)
                {
                    PropertyInfo propertyInfo = rootType.GetProperty(property);
                    if (propertyInfo == null)
                        return null;
                    expr = Expression.Property(expr, propertyInfo);
                    rootType = propertyInfo.PropertyType;
                }
                return Expression.Lambda(expr, arg);
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
