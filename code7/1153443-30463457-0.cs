    public class ProductsController : Controller
    {
        // other methods removed
        // ...
        
        [ChildActionOnly]
        public ActionResult BuildProductTable()
        {
            
            if (User.IsInRole("Admin"))
            {
                // Return Admin ViewModel & Partial View
                // Create and populate Admin ViewModel here
                return PartialView("_AdminProductTable", ProductsAdminVM);
            } 
            // Create and populate Customer ViewModel here
            return PartialView("_CustomerProductTable", ProductsCustomerVM );
        }
    }
