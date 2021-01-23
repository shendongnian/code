    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
        }
        public virtual int Id { get; set; }
    }
    public static void Look<TEntity>(LEBAEntities db, TEntity entity) where TEntity : BaseEntity {
        if(entity.Id == 0)
            db.Entry(entity).State = EntityState.Added;
        else
            db.Entry(entity).State = EntityState.Modified;
    }
 
