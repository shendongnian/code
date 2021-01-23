    public static TEntity LoadCollection<TEntity, TItem>(
            this TEntity entity, 
            Func<TEntity, IList<TItem>> listGetter)
        where TEntity : class
    {
        using (var session = NHibernateHelper<T>.OpenSession())
        {
            // here we get brand new - connected - instance of TEntity
            TEntity reAttached = session.Merge<TEntity>(entity);
            NHibernate.NHibernateUtil
                .Initialize(listGetter.Invoke(reAttached));
            return reAttached;
        }
    }
