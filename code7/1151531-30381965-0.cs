    System.Linq.Expressions.Expression<Func<Foo, bool>> c = k => 
        (k.Name == "Tiddles" &&  k.Age== 21) || k.Age < 21;
    public static IList<T> All(Expression<Func<T, bool>> expression)
    {
        using (var session = NHibernateHelper<T>.OpenSession())
        {
            return session.QueryOver<T>()
                .Where(expression)
                .List();
        }
    }
