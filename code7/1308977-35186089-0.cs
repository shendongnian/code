    public class MyDropdownTestController {
        
        // GET MyDropdownTest/Index
        [HttpGet]
        public ActionResult Index() {
            var vm = new ContainsADropdownViewModel();
            vm.RawOptions = GetCrimsDetails(); // read from backend
            return View("Index", vm);
        }
    
        // POST MyDropdownTest/Index
        [HttpPost]
        public ActionResult Index(ContainsADropdownViewModel vm) {
            var optionChosenByUser = vm.Selected;
            // process form, send HTTP 200 OK or whatever
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
