    public class VmCustomerDetail
    {
        private ICustomerService customerService;
        public Customer CustomerDetail {get; set;}
        
        public async void Refresh(int id){
            CustomerDetail = customerService.GetById(id);
        }
    }
    public class Customer
    {
         public string FullName { get; set; }
         public string Address { get; set; }    
    }
    public interface ICustomerService{
        Customer GetById(int id);
    }
    public class CustomerService : ICustomerService{
        Customer GetById(int id){
           //...
        }
    }
