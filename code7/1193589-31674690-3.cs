    public class MyRepo : IRepository<MyClass> // MyClass needs to implement IEntity
    {
        private readonly DBContext _context;
        public MyRepo(DBContext context)
        {
            _context = context;
        }
        public List<MyClass> List()
        {
            return _context.Table.ToList();
        }
    
        // Other implementations of the IRepository interface
    }
