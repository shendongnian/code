    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    
        [HttpPost]
        public JsonResult PostDriversModel(DriversModel model)
        {
            return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
        }
    
        [HttpGet]
        public JsonResult GetDriversModel()
        {
            var model = new DriversModel
            {
                Drivers = new List<Driver>
                {
                    new Driver
                    {
                        FullName = "John Doe",
                        Cars = new List<Car>
                        {
                            new Car {Code = "car0", Name = "Amazing car"},
                            new Car {Code = "car1", Name = "Cool car"}
                        },
                    },
                    new Driver
                    {                        
                        FullName = "Johnny Dough",
                        Cars = new List<Car>
                        {
                            new Car {Code = "car2", Name = "Another Amazing car"},                      new Car {Code = "car3", Name = "Another Cool car"}
                        }
                    },
                }
            };
    
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
