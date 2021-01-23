    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Data;
    using System.Data.Entity;
    using TemplateBootstrap.Models;
    
    namespace TemplateBootstrap.Controllers
    {
        public class HomeController : Controller
        {
            //private DBEntities db = new DBEntities();
            //This will provide your context to your HomeController
            private readonly ApplicationDbContext _context;
        //Then declare your public context.
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
    
            public ActionResult Index()
            {
                return View(_context.MainNavLevel1.ToList());
            }
    
            public ActionResult About()
            {
                ViewBag.Message = "Your app description page.";
                return View();
            }
    
            public ActionResult Contact()
            {
                ViewBag.Message = "Your contact page.";
                return View();
            }
        }
    }
