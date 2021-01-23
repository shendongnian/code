    [AuthorizeWithLDAP("theController")]
    public class BlogController : Controller
    {
        ....
        [AuthorizeWithLDAP("theFunction")]
        public ViewResult Index()
        {
             return View();
        }
    }
