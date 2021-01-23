    [SessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
    public class TestController : Controller
    {
        public ActionResult Index()
        {
            System.Threading.Thread.Sleep(10000);
            return new EmptyResult();
        }
    }
 
