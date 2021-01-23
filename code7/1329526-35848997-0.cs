    public class MyController : Controller {
    
        public ActionResult Index() {
            populateDropDownLists();
            
            MyViewModel model = GetDefaultViewModel();
            return View(model);
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(MyViewModel viewMod) {
            processMyViewModel(viewMod);
            populateDropDownLists();
            return View(viewMod);
        }
    
        void populateDropDownLists() {
            //These could be cached lists
            ViewBag.List1 = GetList1();
            ViewBag.List2 = GetList1();
            ViewBag.List3 = GetList1();
        }
    }
