    public class MyClass
    {
        private readonly IRepositoryBase[] repos; 
    
        public MyClass (IEnumerable<IRepositoryBase> r)
        {
            repos = r.ToArray();
        }
        
        // ...
    }
