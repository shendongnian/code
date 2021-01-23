    public abstract class MyBaseController : ApiController
    {
        public int UserID
        {
            get { return User.Identity.GetUserId<int>(); }
        }
    }
    
    public class MyNormalController : MyBaseController
    {
        public ActionResult Index()
        {
            var userId = UserID; // put in variable to avoid multiple calls
           // some code ... 
        }
    }
