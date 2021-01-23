    public class CustomerService
    {
        public ValidCustomerDto GetValidCustomer()
        {
             _customerRepository.GetValidCustomer().Select(x=> new ValidCustomerDto{ FirstName = x.FirstName, LastName = x.LastName });
        }
    }
