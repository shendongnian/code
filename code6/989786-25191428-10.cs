    [CreationPolicy(CreationPolicy.Scoped)]
    public class CustomerRepository : IRepository<Customer>
    {
        public CustomerRepository(DbContext context) { }
        public Customer GetById(Guid id) {
            // etc.
        }
    }
