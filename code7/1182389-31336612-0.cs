    public class Service<TEntity> where TEntity : IEntity
    {
        // other code omitted 
        public virtual void Insert(TEntity entity)
        {
            entity.Created = DateTime.Now;
    
            // other code omitted
        }
    }
