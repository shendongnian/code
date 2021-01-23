    public abstract class AbstractClass
    {
        public abstract void DoSomething();
    }
    public class Operations
    {
        public void Method1()
        {
            //Does something
        }
        public void Method2()
        {
            //Apparently does something comopletely different
        }
    }
    public class ConcreteClass1 : AbstractClass
    {
        private Operations _operations;
        
        public override void DoSomething()
        {
            _operations.Method1();
        }
    }
    public class ConcreteClass2 : AbstractClass
    {
        private Operations _operations;
        public override void DoSomething()
        {
            _operations.Method2();
        }
    }
