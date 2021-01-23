    public class MyController : MyController
    {
        private IMyRepo myrepo;
        public MyController(IMyRepo myRepo)
        {
            this.myRepo = myRepo;
        }
    
        public ActionResult Index()
        {
            myrepo.DoSomething()
        }
    }
