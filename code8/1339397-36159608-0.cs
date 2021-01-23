    public class ClassA
    {
        IMyRepo myRepo;
        public ClassA()
        {
          myRepo = Container.Resolve<IMyRepo>();
        }
    
        public void DoSomething()
        {
            var classB = new ClassB(myRepo);
            // ...
        }
    }
