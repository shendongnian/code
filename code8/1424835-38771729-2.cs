    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController {
        //GET api/customer/country/germany
        [HttpGet, Route("country/{country}")]
        public IEnumerable<Customer> GetCustomersByCountry(string country) {
            return repository.GetAll().Where(
                c => string.Equals(c.Country, country, StringComparison.OrdinalIgnoreCase));
        }    
    }
