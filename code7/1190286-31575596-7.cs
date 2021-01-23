    public static Expression<Func<Airplane, bool>> UseTest(string b)
    {
      var param = Expression.Parameter(typeof(Airplane));
      return Expression.Lambda<Func<Airplane, bool>>(Test(Expression.Property(param, typeof(Airplane).GetProperty("Status")), b), param);
    }
