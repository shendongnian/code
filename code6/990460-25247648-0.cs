    public interface IFooEntity : IDisposable
    {
        IEnumerable<Foo> Get();
    }
    public class FooRepository : IFooEntity
    {
        private readonly Entities _context;
        public FooService()
        {
            this._context = new Entities();
        }
        public IEnumerable<Foo> Get()
        {
            return _context.Foo;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
