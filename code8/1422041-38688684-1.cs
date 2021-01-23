    public abstract class TheBaseClass
    {
        public void DoSomething()
        {
            Run();
            SomeOtherBaseClassMethod();
            InheritedClassMethod();
        }
        private void Run()
        {  
            //This method in the base class always gets called.
            //You don't need to explicitly require someone
            //to call it.
        }
        private void SomeOtherBaseClassMethod()
        {
            //So does this one.
        }
        protected abstract void InheritedClassMethod();   
    }
