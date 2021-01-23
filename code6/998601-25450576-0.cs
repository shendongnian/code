    public virtual Division GetById(id)
    {
        var session = ... // ISessionFactory gets session
        return session.Get<Division>(id);
    }
