    public abstract class TheBaseClass
    {
        public void Run()
        {
            SomeBaseClassMethod();
            SomeOtherBaseClassMethod();
            InheritedClassMethod();
        }
        private void SomeBaseClassMethod()
        {  
        }
        private void SomeOtherBaseClassMethod()
        {
        }
        protected abstract void InheritedClassMethod();   
    }
