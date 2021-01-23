    public class SomeClass : IDisposable
    {
        private readonly DataClasses1DataContext _context;
        public SomeClass()
        {
            _context = new DataClasses1DataContext();
        }
    
        public void Dispose();
        {
            _context.Dispose();
        }
        public void Method1();
        {
            // You can use the _context here
        }
        public void Method2();
        {
            // You can use the _context here
        }
        ... 
    }
