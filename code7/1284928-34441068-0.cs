    public class AdminController
    {
      private YourDbContext db;
      public AdminController()
      {
        db = new YourDbContext();
      } 
      public ActionResult Users()
      {
        var list=db.Users.ToList();
        //use list as needed now
      }
    }
