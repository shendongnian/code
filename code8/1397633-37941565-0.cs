    namespace MVCExample.Controllers
    {
        public class Person
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
    
        public class ExampleController : Controller
        {
            public ActionResult Index()
            {
                var p1 = new Person { ID = 1, Name = "P1" };
                var p2 = new Person { ID = 2, Name = "P2" };
                var people = new List<Person> { p1, p2 };
    
                return View(people);
            }
    
            public PartialViewResult _GetPartialView(string date)
            {
                ViewBag.Date = date;
                return PartialView("~/Views/Example/_Partial.cshtml");
            }
    
            public JsonResult ValidateDate(int id, string date)
            {
                //Validate your date here and return appropriate response...
                return Json(new { IsValid = true }, JsonRequestBehavior.AllowGet);
            }
        }
    }
