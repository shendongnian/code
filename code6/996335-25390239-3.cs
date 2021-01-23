    public class CustomerRepository {
        public CustomerRepository(DbContext context) { 
            if (context == null) throw new ArgumentNullException("context");
            this.context = context; 
        }
        public IList<Customer> GetAll() { return context.Customers.ToList(); }
        public IList<Invoice> GetInvoicesFor(Customer customer) {
            return context.Invoices
                .Where(invoice => invoice.Customer.Id == customer.Id)
                .ToList();
        }
        private readonly DbContext context;
    }
