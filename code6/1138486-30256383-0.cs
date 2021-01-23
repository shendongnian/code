    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(typeof(DbContext));
        }
    }
    public class Entity
    {
        private DataContext _context;
        public Entity(DataContext context)
        {
            _context = context;
        }
        public void DoSomething()
        {
            // use _context here
        }
    }
