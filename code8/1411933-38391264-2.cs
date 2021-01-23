    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var s1 = new Server { PersonalID = 1, Name = "Name 1", Surname = "Surname 1", Department = "IT", Job = "Dev", Salary = 10.00M };
            var s2 = new Server { PersonalID = 1, Name = "Name 2", Surname = "Surname 2", Department = "IT", Job = "Dev", Salary = 10.00M };
            var s3 = new Server { PersonalID = 1, Name = "Name 3", Surname = "Surname 3", Department = "IT", Job = "Dev", Salary = 10.00M };
            var s4 = new Server { PersonalID = 1, Name = "Name 4", Surname = "Surname 4", Department = "IT", Job = "Dev", Salary = 2.10M };
            var s5 = new Server { PersonalID = 1, Name = "Name 5", Surname = "Surname 5", Department = "IT", Job = "Dev", Salary = 2.20M };
            var s6 = new Server { PersonalID = 1, Name = "Name 6", Surname = "Surname 6", Department = "IT", Job = "Dev", Salary = 2.33M };
            return View(new List<Server> { s1, s2, s3, s4, s5, s6 });
        }
    }
