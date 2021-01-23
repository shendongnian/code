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
    public class TheInheritedClass : TheBaseClass
    {
        protected override void InheritedClassBehavior()
        {
            //The inherited class has its own behavior here.
            //But this method can't be called directly because
            //it's protected. Someone still has to call
            //DoSomething() in the base class, so AlwaysDoThis()
            //is always called.
        }
    }
