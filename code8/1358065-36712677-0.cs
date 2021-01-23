    public class Teacher
    {
      public int TeacherId { get; set; }
      public string Code { get; set; }
      public string Name { get; set; }
    } 
    public class Student
    {
      public int StudentId { get; set; }
      public string Code { get; set; }
      public string Name { get; set; }
      public string EnrollmentNo { get; set; }
    }
     
     Controller Code
     public class HomeController : Controller
     {
         public ActionResult Index()
         {
            ViewBag.Message = "Welcome to my demo!";
            dynamic mymodel = new ExpandoObject();
            mymodel.Teachers = GetTeachers();
            mymodel.Students = GetStudents();
            return View(mymodel);
         }
     }
