    public class DashboardController : MyAuthentication  
    {
    
        public ActionResult Index()
        {
            var categories = db.Categories.ToList();
            return View(categories);
        }
        // rest of the codes
    }
