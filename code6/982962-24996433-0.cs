    public interface IFooObjectRepository
    {
        IEnumerable<FooObject> Get();
    }
    public class FooObject
    {
        public int Id { get; set; }
        public string Bar { get; set; }
    }
    public class CsvFooObjectRepository : IFooObjectRepository
    {
        public IEnumerable<FooObject> Get()
        {
            // Implementation
        }
    }
    public class InMemoryFooObjectRepository : IFooObjectRepository
    {
        public IEnumerable<FooObject> Get()
        {
            // Implementation
        }
    }
    public class DbFooObjectRepository : IFooObjectRepository
    {
        public IEnumerable<FooObject> Get()
        {
            // Implementation
        }
    }
    public class FooObjectService
    {
        private readonly IFooObjectRepository _repo;
        public FooObjectService(IFooObjectRepository repo)
        {
            this._repo = repo;
        }
        public void GetFooObjects()
        {
            IEnumerable<FooObject> = this._repo.Get();
            // Regardless of implementation of IFooObjectRepository, you'll get your IEnumerable<FooObject> from either your Csv, InMemory, or Db.
        }
    }
