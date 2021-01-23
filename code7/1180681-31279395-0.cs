    public abstract class GeneralService<T>
    {
        private IRepository<T> _repository;
        public GeneralService(IRepository<T> repository)
        {
            _repository = repository;
        }
        public abstract void Delete(int Id);
        public abstract IEnumerable<T> GetAll();
        public abstract IEnumerable<T> GetDisplayed();
        public abstract T Get(int Id);
        public abstract T Save(T t);
        public abstract IEnumerable<Product> GetProducts(int Id);
    }
    public interface IRepository<T>
    {
        ...
    }
