    public static class PropertyUtility
    {
       public static string GetProperty<T>(this T entity, Expression<Func<T, object>> selector)
       {
          return ((MemberExpression)selector.Body).Member.Name;
       }
    }
