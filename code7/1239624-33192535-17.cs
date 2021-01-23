    public interface IDatabaseContext
    {
        IDbSet<Customer> Customers { get; }
    }
    public class MyContext : DbContext, IDatabaseContext
    {
        public IDbSet<Customer> Customers { get; set; }
    }
    public class Repository : IRepository
    {
        private IDatabaseContext m_Context;
        public Repository(IDatabaseContext context)
        {
            m_Context = context;
        }
        public void AddCustomer(Customer customer)
        {
            m_Context.Customers.Add(customer);      
        }
    }
