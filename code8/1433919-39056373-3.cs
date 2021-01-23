    public virtual Guid Add<T>(T entity) where T : BaseEntity
        {
            using (var context = new ApplicationDbContext())
            {
                DbSet dbSet = context.Set<T>();
                dbSet.Add(entity);
                context.SaveChanges();
                return entity.Id;
            }
        }
    
    public abstract class BaseEntity
    {
       public Guid Id { get; set;}
    }
