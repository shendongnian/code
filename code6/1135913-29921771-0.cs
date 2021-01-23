    public T GetByProperty<T>(string propertyName, object value)
        where T: class
    {
        var session = ... // get a session
        return session.CreateCriteria<T>()
            .Add(Restrictions.Eq(propertyName, value))
            .SetMaxResults(1)
            .List<T>()
            .FirstOrDefault();
    }
