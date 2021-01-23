    using System;
    using System.Web.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace HelloWorld
    {
    	public class HomeController : Controller
    	{
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
                // this is redundant 
                // but illustrates how to access the selected id  
    			vm.SelectedPersonID = vm.SelectedPersonID;
    			vm.Persons = PersonsRepo;
    			return View(vm);
    		}
    		
            // this is just fake DB access
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
    	}
    }
