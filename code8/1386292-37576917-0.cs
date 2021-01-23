    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Assume this would really come from your database.
            var employees = new List<EmployeeViewModel>()
            {
                new EmployeeViewModel { Id = 1, Name = "Employee 1" },
                new EmployeeViewModel { Id = 2, Name = "Employee 2" },
                new EmployeeViewModel { Id = 3, Name = "Employee 3" },
            };
            return View(employees);
        }
        [HttpPost]
        public ActionResult Index(List<EmployeeViewModel> employees)
        {
            // Rest of action
        }
    }
