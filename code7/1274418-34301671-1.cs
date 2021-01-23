    public class CustomersController : ODataController
    {
        private List<Customer> customers = new List<Customer>
        {
            new Customer { Id = 1, IsActive = false },
            new Customer { Id = 2, IsActive = true,
                Contacts = new List<Contact>
                {
                    new Contact { Id = 101, IsActive = true },
                    new Contact { Id = 102, IsActive = false },
                    new Contact { Id = 103, IsActive = true },
                }
            }
        };
        [EnableQuery]
        public IHttpActionResult Get()
        {
            return Ok(customers.Where(c => c.IsActive).AsQueryable());
        }
    }
