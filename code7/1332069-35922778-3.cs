    public interface IContext {
        //....
        IContextOrmOptions Options { get; set; }
    }
    public interface IContextOrmOptions {
        bool AutoDetectChanges { get; set; }
        bool LazyLoadingEnabled { get; set; }
        //etc..
    }
    //real implementation
    public class EntityFrameworkContextOrmOptions : IContextOrmOptions {
        private DbContext _dbContext;
        public EntityFrameworkContextOrmOptions(DbContext dbContext) {
            dbContext = _dbContext; 
        }
        public bool AutoDetectChanges {
            { get { return _dbContext.Configuration.AutoDetectChangesEnabled; } }
            { set { _dbContext.Configuration.AutoDetectChangesEnabled = value; } }
        }
    }
