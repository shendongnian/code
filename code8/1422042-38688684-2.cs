    public abstract class TheBaseClass
    {
        public void DoSomething()
        {
            AlwaysDoThis();
            InheritedClassBehavior();
        }
        private void AlwaysDoThis()
        {  
            //This method in the base class always gets called.
            //You don't need to explicitly require someone
            //to call it.
        }
        protected abstract void InheritedClassBehavior();   
    }
