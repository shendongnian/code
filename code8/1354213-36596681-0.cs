    public abstract class MyBaseController : Controller
    {
        public int UserID
        {
            get { return int.Parse(User.Identity.Name); }
        }
    
        // other useful methods & properties...
    }
