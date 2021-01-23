    interface IDao<TEntity> where TEntity : IEntity
    {
        TEntity Save(TEntity ent);
        IQueryable<TEntity> GetAll();
        bool Delete(TEntity ent, out String errMsg);
        void SaveChanges();
    }
