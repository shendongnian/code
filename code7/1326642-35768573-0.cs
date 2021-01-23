    public abstract class MyBase
    {
        protected virtual void DoSomething()
        {
            //My Implementation here
            ...
        }
       
        //Will give compile-time error if you don't override this in derived class
        protected abstract void DoSomethingElse();
    }
