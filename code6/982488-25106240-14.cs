    public class CustomersController : ODataController
    {
        private Entities db = new Entities();
        [SecureAccess(MaxExpansionDepth=2)]
        public IQueryable<Customer> GetCustomers()
        {
            return db.Customers;
        }
        // GET: odata/Customers(5)
        [EnableQuery]
        public SingleResult<Customer> GetCustomer([FromODataUri] int key)
        {
            return SingleResult.Create(db.Customers.Where(customer => customer.Id == key));
        }
    }
