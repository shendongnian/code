    interface IDao<TEntity>
    {
        TEntity Save(TEntity ent);
        IQueryable<TEntity> GetAll();
        bool Delete(TEntity ent, out String errMsg);
        void SaveChanges();
    }
