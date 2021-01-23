    public class CustomerController : ApiController {
        readonly ICustomerRepository repository;
    
        public CustomerController(ICustomerRepository repository) {
            this.repository = repository;
        }
    
        //...other code removed for brevity
    }
