    public interface IUnitOfWorkProvider
    {
        IUnitOfWork GetUnitOfWork(string connectionString);
    }
    public static class UnitOfWork
    {
        [ThreadStatic]
        public IUnitOfWork Current { get; set; }
    }
    
    public class PetaPocoUnitOfWorkProvider : IUnitOfWorkProvider
    {
        public IUnitOfWork GetUnitOfWork(string connectionString)
        {
            if (UnitOfWork.Current != null) 
            {
               throw new InvalidOperationException("Existing unit of work.");
            }
            UnitOfWork.Current = new PetaPocoUnitOfWork(connectionString);
            return UnitOfWork.Current;
        }
    }
    
    public interface IRepository<T>
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Fetch(long uid);
    }
    
    public class PetaPocoUnitOfWork : IUnitOfWork
    {
        private readonly Transaction _petaTransaction;
        private readonly Database _database;
    
        public PetaPocoUnitOfWork(string connectionString)
        {
            _database = new Database(connectionString);
            _petaTransaction = new Transaction(_database);
        }
    
        public void Dispose()
        {
            UnitOfWork.Current = null;
            _petaTransaction.Dispose();
        }
    
        public Database Database
        {
            get { return _database; }
        }
    
        public void Commit()
        {
            _petaTransaction.Complete();
        }
    }
    public class BaseRepository<T> : IRepository<T>
    {
        protected IDatabase Db => UnitOfWork.Current;
    }
    
    public class FakeRepository : IRepository<Fake>
    {
        public void Insert(Fake entity)
        {
            Db.Save(entity);
        }
    
        public void Update(Fake entity)
        {
            Db.Update(entity);
        }
    
        public void Delete(Fake entity)
        {
            Db.Delete(entity);
        }
    
        public FakeJobFact Fetch(long uid)
        {
            return Db.Fetch<Fake>("SELECT * FROM Fakes WHERE [FakeId] = @0", uid).FirstOrDefault();
        }
    }
