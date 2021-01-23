    public interface IFactory<T>
    {
        T Create();
    }
    public class Repository : IRepository
    {
        private IFactory<MyContext> m_Factory;
        public Repository(IFactory<MyContext> factory)
        {
            m_Factory = factory;
        }
        public void AddCustomer(Customer customer)
        {
            using (var context = m_Factory.Create())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }            
        }
    }
