    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    
    namespace WebApplication4.Controllers
    {
        [RoutePrefix("products")]
        public class DefaultController : Controller
        {
            // GET: Default
            [Route]
            public ActionResult Index()
            {
                return Content("It Works!");
    
                //return View();
            }
        }
    }
