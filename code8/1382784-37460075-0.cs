    public class X
    {
       private UserService _userService = null;
    
       protected UserService UserService
       {
           get { return _userService ?? Request.GetOwinContext().GetUserManager<UserService>(); }
       }
    
    
       public X() { }
    
       public X(UserService svc) { _userService = svc; }
