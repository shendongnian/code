    public class MyViewModel  //MODEL LAYER
        {
            public int CountryId { get; set; }
        public string CountryName { get; set; }
        public List<Employee> EmployeesList { get; set; }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
    public IActionResult Contact1()  //CONTROLLER
            {
            MyViewModel N1 = new MyViewModel();
            List<Employee> N2 = new List<Employee>()
            {
                new Employee { Id=1,FullName="sivaragu" },
                 new Employee { Id=2,FullName="siva" },
                      new Employee { Id=3,FullName="SENTHIL" }
            };
            ViewBag.MovieType = N2;
            return View();            
        }
