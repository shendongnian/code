    public class Helper
    {
        public DbContext Context { get; private set; }
    
        public Init(DbContext context /* Autofac is going to fill in this */)
        {
            Context = context;
        }
    }
 
