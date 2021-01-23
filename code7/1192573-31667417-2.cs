    public class MyClass<TEntity> where TEntity : class
    {
        public IQueryable<TEntity> ApplySearch(IQueryable<TEntity> originalList, string valueToSearch, string[] columnsToSearch)
        {
            Expression<Func<TEntity, bool>> expression = null;
            foreach (var propName in columnsToSearch)
            {
                Expression<Func<TEntity, bool>> lambda = null;
                ParameterExpression parameterExpression = Expression.Parameter(typeof(TEntity), "p");
                string[] nestedProperties = propName.Split('.');
                Expression member = parameterExpression;
                foreach (string prop in nestedProperties)
                {
                    member = Expression.PropertyOrField(member, prop);
                }
                var canConvert = CanConvertToType(valueToSearch, member.Type.FullName);
                if (canConvert)
                {
                    var value = ConvertToType(valueToSearch, member.Type.FullName);
                    if (member.Type.Name == "String")
                    {
                        ConstantExpression constant = Expression.Constant(value);
                        MethodInfo mi = typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });
                        Expression call = Expression.Call(member, mi, constant);
                        lambda = Expression.Lambda<Func<TEntity, bool>>(call, parameterExpression);
                    }
                    else
                    {
                        lambda = Expression.Lambda<Func<TEntity, bool>>(Expression.Equal(member, Expression.Constant(value)), parameterExpression);
                    }
                }
                if (lambda != null)
                {
                    if (expression == null)
                    {
                        expression = lambda;
                    }
                    else
                    {
                        expression = expression.Or(lambda);
                    }
                }
            }
            if (expression != null)
            {
                return originalList.Where(expression);
            }
            return originalList;
        }
    }
    private bool CanConvertToType(object value, string type)
    {
        bool canConvert;
        try
        {
            var cValue = ConvertToType(value, type);
            canConvert = true;
        }
        catch
        {
            canConvert = false;
        }
        return canConvert;
    }
    private dynamic ConvertToType(object value, string type)
    {
        return Convert.ChangeType(value, Type.GetType(type));
    }
