    interface IFooBarController
    {
        void DoSomething();
    }
    abstract class AbstractFooBarController  : IFooBarController
    {
        [HttpPost]
        public abstract void DoSomething();
    }
    public class FooBarController : AbstractFooBarController  
    {
        [HttpPost]
        public void DoSomething()
        {
           // This API method can only be called using POST,
           // as you would expect from the interface.
        }
    
        public void Delete(int id)
        {
            // This API method can only be called using DELETE,
            // even though the interface specifies [HttpPost].
        }
    }
