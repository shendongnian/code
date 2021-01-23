    public abstract class Entity<TEntity, TDbContext, TViewModel>
        where TEntity : Entity<TEntity, TDbContext, TEntityViewModel>
        where TDbContext : Entity<TEntity, TDbContext, TEntityViewModel>.BaseDbContext, new()
        where TViewModel : Entity<TEntity, TDbContext, TEntityViewModel>.BaseViewModel
    {
        public class EntityController
        {
            protected TDbContext CreateContext() { return new TDbContext(); }
        }
        public abstract class BaseDbContext
        {
            public abstract void Create(TViewModel entity);
            public abstract List<TViewModel> Read(ModifyData data);
            public abstract void Update(TViewModel entity);
            public abstract void Delete(TViewModel entity);
        }
        public abstract class BaseViewModel {}
        
    }
    
