    public class MyController : Controller {
    
        public ActionResult SubmitNewValue() {
            populateDropDownLists();
            
            MyViewModel model = GetDefaultViewModel();
            return View(model);
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitNewValue(MyViewModel viewMod) {
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
