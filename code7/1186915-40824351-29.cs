    [Permission("AccessCustomers")]
    public class CustomersController
    {
        [Permission("AddCustomer")]
        IActionResult AddCustomer([FromBody] Customer customer)
        {
            //Add customer
        }
    }
