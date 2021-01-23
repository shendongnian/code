    public class HomeController
    {
        private readonly IResourceFactory resourceFactory;
        public HomeController(IResourceFactory resourceFactory)
        {
            this.resourceFactory = resourceFactory;
        }
        public ActionResult Index()
        {
            var banner = this.resourceFactory.CreateBanner();
            ....
        }
    }
