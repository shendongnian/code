    public enum CustomerTypes 
    {
        INDIVIDUAL = 0,
        COMPANY
    }
    
    public class CustomerViewModel
    {
        public CustomerTypes Type { get; set; }
    
        public string[] CustomerTypesSelectList { get; set; }
    }
    public class CustomerController : Controller
    {
        public ActionResult Edit()
        {
            var model = new CustomerViewModel();
            model.CustomerTypesSelectList = 
                Enum.GetNames(typeof(CustomerTypesSelectList));
    
            return View(model);
        }
    }
