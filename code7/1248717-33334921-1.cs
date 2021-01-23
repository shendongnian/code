    public class HomeController : Controller
    {
    	public IEnumerable<Customer> Customers
        {
            get
            {
                return new List<Customer>
                {
                    new Customer { CustomerId = 1, CustomerName = "Thor" },
                    new Customer { CustomerId = 2, CustomerName = "Iron Man" },
    				new Customer { CustomerId = 3, CustomerName = "Hawk Eye" }
                };
            }
        }
    
        public ActionResult Index()
        {
            ViewBag.CustomerId = new SelectList(Customers, "CustomerId", "CustomerName");    
            return View();
        }
        
    
        public ActionResult Submit(Customer customer)
        {
    		//Send selected CustomerId back to the view
            ViewBag.CustomerId = new SelectList(Customers, "CustomerId", "CustomerName", customer.CustomerId);
            return View("Index");
        }
    }
