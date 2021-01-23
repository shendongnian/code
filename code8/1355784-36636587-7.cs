    public class MyClass
    {
        private ApplicationDbContext _context;
        public MyClass(ApplicationDbContext context)
        {
            _context = context;
        }
    }
    public class AnotherClass
    {
        private ApplicationDbContext _context;
        private MyClass _myClass;
        public AnotherClass(ApplicationDbContext context, MyClass myClass)
        {
            _context = context;
            _myClass = myClass;
        }
    }
