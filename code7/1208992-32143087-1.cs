    interface IRepository<TEntity> {
        TEntity GetById(Guid id);
        // Creates an entity that gets saved when the transaction is committed,
        // optionally using an id supplied by the client.
        TEntity Create(Guid? id = null);
    }
