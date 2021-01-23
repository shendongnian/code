    public class MyController : Controller
    {
    private IUser _user;
    
         // Ninject will automatically inject a User instance here
         // on controller creation
         public MyController(IUser user)
         {
             _user = user;
         }
    }
