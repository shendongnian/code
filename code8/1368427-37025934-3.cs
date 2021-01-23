    public class CustomerViewModel
    {
         public CustomerViewModel()
         {
              Customers = new List<Customer>();
         }
    
         public List<Customer> Customers { get; set; }
    
         public string StoreName { get; set; }
    }
