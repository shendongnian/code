    using System.Linq;
    
    public interface IRepository<TEntity, in TKey>
    {
    
        TEntity Get(TKey id);
    
        IQueryable<TEntity> All();
    }
    
    public interface IRepository
    {
        void GetAll();
        void GetById(int id);
    }
    
    public interface IDeleteRepository : IRepository
    {
        void Delete();
    }
    
    public interface ICreateRepository : IRepository
    {
        void Create();
    }
    
    
    public class Wrapper
    {
        private readonly CombinedRepository standardRepository = new CombinedRepository();
    
        public IRepository Repository
        {
            get { return standardRepository; }
        }
    
        public ICreateRepository CreateRepository
        {
            get { return standardRepository; }
        }
    
        public IDeleteRepository DeleteRepository
        {
            get { return standardRepository; }
        }
    }
    
    public class CombinedRepository : IRepository, IDeleteRepository, ICreateRepository
    {
        public void GetAll()
        {
        }
    
        public void GetById(int id)
        {
        }
    
        public void Delete()
        {
        }
    
        public void Create()
        {
        }
    }
