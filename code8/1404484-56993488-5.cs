    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;
    
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
    
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
    
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee newEmployee = _employeeRepository.Add(employee);
            }
    
            return View();
        }
    }
