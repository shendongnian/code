    public class HomeController : Controller
    {
        public ActionResult Index(){
            var context = new MyContext();
            var firstSession = context.Sessions.First();
            var viewModel = new SessionView 
            {
                SessionId = firstSession.SessionId,
                CourseId = firstSession.CourseId,
                //keep populating here if you need
            };
            return View(viewModel);
        }
    }
