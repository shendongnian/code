    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using WebApplication2.Models;
    
    namespace WebApplication2.Controllers
    {
        public class AdminController : Controller
        {
            // GET: Admin
            public ActionResult Admin()
            {
                Category category = new Category() { Name = "TestC" };
                List<Rec> rc = new List<Rec>()
                {
                    new Rec() { RecId=1, RecTitle="Test" }
                };
    
                AdminViewModel adminViewModel = new AdminViewModel();
                adminViewModel.category = category;
                adminViewModel.recs = (IEnumerable<Rec>)rc;
    
                return View(adminViewModel);
            }
        }
    }
