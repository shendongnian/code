        private static IEnumerable<string> GetPropertyName<TObj, TProp>(params Expression<Func<TObj, TProp>>[] propCollection)
        {
            foreach (var prop in propCollection)
            {
                var expression = prop.Body as MemberExpression;
                if (expression != null)
                {
                    var property = expression.Member as PropertyInfo;
                    if (property != null)
                    {
                        yield return property.Name;
                    }
                }
                yield return string.Empty;
            }
        }
