    public class Helper
    {
        public DbContext Context { get; private set; }
    
        public Helper(DbContext context /* Autofac is going to fill in this */)
        {
            Context = context;
        }
    }
