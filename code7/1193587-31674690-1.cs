    public class MyRepo : IRepository<MyClass>
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
