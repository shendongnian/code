    public class MyBaseController : Controller
    {
       protected YourDbContext db;
       public MyBaseController ()
       {
          db = new YourDbContext();
       }   
    }
    public class AdminController : MyBaseController
    {
     
    }
