     public class ArticleController : Controller
    {
        readonly INotifier notifier;
        public ArticleController(INotifier notifier)
        {
           this.notifier = notifier;
        }
       
        // GET: Content
        public ActionResult Index()
        {
            notifier.Success("Yahoo!");
            return View();
            
        }
