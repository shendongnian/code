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
    			
    			var vm = new MyViewModel {
    				SelectedPerson = persons.FirstOrDefault(),
    				Persons = persons
    			};
    
    			return View(vm);
    		}
    
    		[HttpPost]
    		public ActionResult Index(string question)
    		{
    			// todo, get the PersonID
    			return View(new Person());
    		}
    	}
    }
