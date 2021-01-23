    public abstract class MyBase
    {
        protected virtual void DoSomething()
        {
            //My Implementation here
            Console.WriteLine("Base implementation");
        }
       
        //Will give compile-time error if you don't override this in derived class
        protected abstract void DoSomethingElse();
    }
