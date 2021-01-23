      // my generic repository
      public class EntityBaseRepository<T>:IEntityBaseRepository<T> 
       where T :class , new()
     {
        //my context
        private DataContext dbContext;
        
         // use Dependency injection 
          public EntityBaseRepository(DataContext _dbContext)
       {
          this.dbContext = _dbContext;
           
       }
 
         //update method
           public void Update(T entity)
        {
            DbEntityEntry entry = this.dbContext.Entry(entity);
            entry.State = EntityState.Modified;
        }
     }
     // at the end call DbContext SaveChanges() from controller
