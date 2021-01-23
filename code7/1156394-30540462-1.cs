    public static object First(this IQueryable source)
            {
                if (source == null) throw new ArgumentNullException("source");
                return source.Provider.Execute(
                    Expression.Call(
                        typeof(Queryable), "First",
                        new Type[] { source.ElementType },
                        source.Expression));
            }
