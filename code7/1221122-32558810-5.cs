    [NHibernateTransaction]
    public void Create<TEntity>(TEntity entity) where TEntity : class, IIdentity   
    {       
        session.Save(entity);
    }
