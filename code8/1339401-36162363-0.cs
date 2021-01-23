    public class MyController : MyController
    {
        private ClassA classA;
        public MyController(ClassA classA)
        {
            this.classA = classA;
        }
    
        public ActionResult Index()
        {
            classA.DoSomething()
            //...
        }
    }
    
    public class ClassA
    {
        private ClassB classB;
        public ClassA(ClassB classB)
        {
            this.classB = classB;
        }
    
        public void DoSomething()
        {
            // ...
        }
    }
    
    public class ClassB
    {
        private IMyRepo repo;
        public ClassB(IMyRepo myRepo)
        {
            this.myRepo = myRepo;
        }
    }
