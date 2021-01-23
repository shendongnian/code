    public class ManageController
    {
        private readonly ApplicationDbContext _context;
        public ManageController(ApplicationDbContext context)
        {
            _context = context;
        }
    }
