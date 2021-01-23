    using System;
    using System.Web.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace HelloWorld
    {
    	public class HomeController : Controller
    	{
            public List<Person> PersonsRepo
            {
                get
                {
    			    var persons = new List<Person>();
    		    	for (var i = 0; i < 10; ++i)
    		    	{
    			    	persons.Add(new Person()
    				    {
    				        First = "First" + i, 
    						Last = "Last" + i, 
    						PersonID = i
    				    });
    		    	}
    
                    return persons; 
    	        }
            }
    
    		[HttpGet]
    		public ActionResult Index()
    		{
    			var vm = new MyViewModel {
    				SelectedPersonID = PersonsRepo.FirstOrDefault().PersonID,
    				Persons = PersonsRepo
    			};
    
    			return View(vm);
    		}
    
    		[HttpPost]
    		public ActionResult Index(MyViewModel vm)
    		{
    			vm.SelectedPersonID = vm.SelectedPersonID;
    			vm.Persons = PersonsRepo;
    			return View(vm);
    		}
    	}
    }
