    using System.Web.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace HelloWorld
    {
        public class HomeController : Controller
        {
    		public FakeDb fakeDb = new FakeDb();
    		
            [HttpGet]
            public ActionResult Index()
            {
                var vm = new MyViewModel {
                    SelectedPersonID = fakeDb.Persons.FirstOrDefault().PersonID,
                    Persons = fakeDb.Persons
                };
    
                return View(vm);
            }
    
            [HttpPost]
            public ActionResult Index(MyViewModel vm)
            {
                // this is redundant 
                // but illustrates how to access the selected id  
                vm.SelectedPersonID = vm.SelectedPersonID;
                vm.Persons = fakeDb.Persons;
    
                return View(vm);
            }
        }
    }
