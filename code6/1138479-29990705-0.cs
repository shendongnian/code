    public class CustomerController : Controller
    {
        public ActionResult Index()
        {
            Customer Obj = new Customer();
           
            Obj.Name = "Sourav ";
           
            Obj.Surname = "Kayal";
           
            Session["Customer"] = Obj;
            return View();
        }
 
    }
    }
    Create a view to display data
