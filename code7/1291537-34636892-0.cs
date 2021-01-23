    public static class MkpExtensions
    {
        public static IEnumerable<T> OrderByField<T>(this IEnumerable<T> list, string sortExpression)
        {
            sortExpression += "";
            string[] parts = sortExpression.Split(' ');
            bool descending = false;
            string fullProperty = "";
            if (parts.Length > 0 && parts[0] != "")
            {
                fullProperty = parts[0];
                if (parts.Length > 1)
                {
                    descending = parts[1].ToLower().Contains("esc");
                }
                ParameterExpression inputParameter = Expression.Parameter(typeof(T), "p");
                Expression propertyGetter = inputParameter;
                foreach (string propertyPart in fullProperty.Split('.'))
                {
                    PropertyInfo prop = propertyGetter.Type.GetProperty(propertyPart);
                    if (prop == null)
                        throw new Exception("No property '" + fullProperty + "' in + " + propertyGetter.Type.Name + "'");
                    propertyGetter = Expression.Property(propertyGetter, prop);
                }
                var getter = Expression.Lambda<Func<T, object>>(propertyGetter, inputParameter).Compile();
                if (descending)
                    return list.OrderByDescending(getter);
                else
                    return list.OrderBy(getter);
            }
            return list;
        }
    }
