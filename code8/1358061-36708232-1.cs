    public class EmployeeController
    {
         public IActionResult Index()
         {
             var empInfo = new EmployeeInfo(employee, store, address); // retrieved from database somehow
             return View(empInfo);
         }
    }
