    public class CustomerController : ApiController
    {
        [Route("api/Customer/{model.LastName}/{model.FirstName}/Upload")]
        public void Post(CustomerModel model)
        {
             // ...
        }
    }
