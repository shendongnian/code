    [Route("/customers", "GET")]
    public class GetCustomers : IReturn<List<Customer>> { }
    [Route("/customers/{Id}", "GET")]
    public class GetCustomer : IReturn<Customer>
    {
        public int Id { get; set; }
    }
    [Route("/customers", "POST")]
    public class CreateCustomer : IReturn<Customer>
    {
        public string Name { get; set; }
    }
    [Route("/customers/{Id}", "PUT")]
    public class UpdateCustomer : IReturn<Customer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    [Route("/customers/{Id}", "DELETE")]
    public class DeleteCustomer : IReturnVoid
    {
        public int Id { get; set; }
    }
