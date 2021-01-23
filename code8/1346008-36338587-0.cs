    public class UsersController : Controller
    {
      [Route("~/admin/users"]
      public ActionResult Index()  { // to do : Return something }
      [Route("~/admin/create"]
      public ActionResult Create()  { // to do : Return something }
      [Route("~/admin/users/{id}"]
      public ActionResult View(int id)  { // to do : Return something }    
    }
