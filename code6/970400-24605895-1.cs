    public List<Customer> GetCustomersList(CustomerQuery customerQuery)
    {
        using (var context = new MyDbContext())
        {
            var customers = context.Customers;
            return customerQuery.Apply(customers).ToList();
        }
    }
