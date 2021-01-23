    [Permission("AccessCustomers")]
    public class CustomersController
    {
        [HttpPost]
        [Permission("AddCustomer")]
        IActionResult AddCustomer([FromBody] Customer customer)
        {
            //Add customer
        }
    }
