    public static IQueryable<T> Include<T, TProperty>(this IQueryable<T> source, Expression<Func<T, TProperty>> path)
    {
      Check.NotNull<IQueryable<T>>(source, "source");
      Check.NotNull<Expression<Func<T, TProperty>>>(path, "path");
      string path1;
      if (!DbHelpers.TryParsePath(path.Body, out path1) || path1 == null)
    	throw new ArgumentException(Strings.DbExtensions_InvalidIncludePathExpression, "path");
      return QueryableExtensions.Include<T>(source, path1);
    }
