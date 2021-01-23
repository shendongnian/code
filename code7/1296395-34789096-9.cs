    public class RepositoryDal : IRepositoryDal
        {
            private readonly DatabaseContext context;
    
            public RepositoryDal()
            {
                this.context = new DatabaseContext();
            }
    
            public T Add<T>(T entity) where T : Entity
            {
                return this.context.Set<T>().Add(entity);
            }
    
            public void Delete<T>(T entity) where T : Entity
            {
                this.context.Set<T>().Remove(entity);
            }
    
            public IQueryable<T> GetAll<T>() where T : Entity
            {
                return this.context.Set<T>();
            }
    
            public T GetById<T>(int id) where T : Entity
            {
                return this.context.Set<T>().FirstOrDefault(x => x.Id == id);
            }
    
            public bool HasChanges()
            {
                return this.context.ChangeTracker.HasChanges();
            }
    
            public void Save()
            {
                this.context.SaveChanges();
            }
    
            public void Dispose()
            {
                this.context.Dispose();
            }
        }
