    public static List<T> ExecList(Func<LinqToSqlDataContext, IQueryable<T>> qf)
    {
        using(var c = new LinqToSqlDataContext())
        {
             var q = qf(c);
             return q.ToList();
        }
    }
