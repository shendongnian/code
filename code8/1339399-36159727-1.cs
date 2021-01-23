    public class MyController : MyController
    {
        private ClassA classA;
        public MyController(IMyRepo myRepo)
        {
            this.classA = myRepo.CreateA();
        }
    
        public ActionResult Index()
        {
            classA.DoSomething()
        }
    }
