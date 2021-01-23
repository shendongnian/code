    public class CustomerController : ApiController {
        [HttpGet]
        public IEnumerable<Customer> GetCustomersByCountry(string country) {
            return repository.GetAll().Where(
                c => string.Equals(c.Country, country, StringComparison.OrdinalIgnoreCase));
        }
    
    }
