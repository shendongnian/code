    public class CustomerController : Controller
    {
         private ICustomerRepository customerRepository;
    
         public CustomerController(ICustomerRepository customerRepository)
         {
              this.customerRepository = customerRepository;
         }
    
         public ActionResult Profile()
         {
              List<CustomerViewModel> customerViewModels = new List<CustomerViewModel>();
              List<Customer> customers = customerRepository.GetAll();
              foreach (Customer customer in customers)
              {
                   CustomerViewModel customerViewModel = new CustomerViewModel();
                   customerViewModel.Id = customer.Id;
                   customerViewModel.Name = customer.Name;
                   // Populate the rest of the properties
                   customerViewModels.Add(customerViewModel);
              }
              
              return View(customerViewModels);
         }
    }
