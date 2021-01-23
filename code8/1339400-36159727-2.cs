    public class MyController : MyController
    {
        private IMyRepo myrepo;
        private Func<ClassA> aFactory;
        public MyController(IMyRepo myRepo, Func<ClassA> aFactory)
        {
            this.myRepo = myRepo;
            this.aFactory = aFactory;
        }
    
        public ActionResult Index()
        {
            var classA = aFactory.Invoke();
            classA.DoSomething()
        }
    }
