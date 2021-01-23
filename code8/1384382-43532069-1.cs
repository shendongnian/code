    public class CustomerRepository: ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }
    }
