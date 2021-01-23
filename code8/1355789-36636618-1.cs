    public class CompanyController : Controller
    {
        private ApplicationDbContext _context;
        private SomeService _someService;
    
        public CompanyController(ApplicationDbContext context, SomeService someService)
        {
            _context = context;
            _someService = someService;
        }
    }
