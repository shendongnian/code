    public IQueryable<Customer> GetCustomers()
    {
    }
    [ResponseType(typeof(Customer))]
    public IHttpActionResult GetCustomer(int id)
    {
    }
    [ResponseType(typeof(void))]
    public IHttpActionResult PutCustomer(int id, Customer customer)
    {
    }
    [ResponseType(typeof(Customer))]
    public IHttpActionResult PostCustomer(Customer customer)
    {
    }
    [ResponseType(typeof(Customer))]
    public IHttpActionResult DeleteCustomer(int id)
    {
    }
