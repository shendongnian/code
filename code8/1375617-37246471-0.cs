    //An assumed abstraction of the ManagerBase
    public abstract class ManagerBase {
        public ManagerBase(IDbContext dbContext, IFactory factories) {
            DbContext = dbContext;
            Factories = factories;
        }
        public IDbContext DbContext { get; private set; }
        public IFactory Factories { get; private set; }
    }
    //An abstraction of what the unit of work would look like
    public interface IDbContext {
        //student repository
        DbSet<Student> Students { get; }
        //...other repositories
        int SaveChanges();
    }
    //Just an example of the Student Factory.
    public interface IModelFactory<T> where T : class, new() {
        T Create(Action<T> configuration);
    }
    public interface IFactory {
        IModelFactory<Student> StudentFac { get; }
        //...other factories. Should try to make your factories Generic
    }
