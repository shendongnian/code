    public abstract class EntityDao<TEntity> : IDao<TEntity> 
    {
        TEntity IDao<TEntity>.Save(TEntity ent)
        {
            bool isNew;
            bool success;
    
            isNew = ent.isNew();
    
            if (isNew)
            {
                ent.getDbSet(Context).Add(ent);
            }
    
            //Context.Entry(ent).State = (isNew) ? EntityState.Added : EntityState.Modified;
    
            SaveChanges();
            return ent;
        }
    }
