    public class Job : IJob
    {
        private readonly IService _service;
        private readonly IDbContext _context;
    
        public Job()
        {
             // this needs to be here, although this won't be used in the actual running
        }
    
        public Job(IService service, IDbContext context) : this()
        {
            _service = service;
            _context = context;
        }
    
        public override void Run(SomeModel searchLocationModel)
        {
        }
    }
