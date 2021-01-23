    public class MyTests: IClassFixture<TestFixture>
    {
        TestFixture fixture;
        public MyTests(TestFixture fixture)
        {
            this.fixture = fixture;
        }
    
        [Fact]
        public void MyFirstTest()
        {
            ICustomerRepository customerRepository = new CustomerRepository(fixture.Configuration);
            CustomerService customerService = new CustomerService(customerRepository);        
    }
