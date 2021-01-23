    public static class Helper
    {
       public static string GetPropertyName<T>(Expression<Func<T>> expression)
       {
          return ((MemberExpression)expression.Body).Member.Name;
       }
    }
