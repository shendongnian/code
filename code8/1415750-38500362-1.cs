    public interface IDoSomethingElseFactory
    {
        IDoSomethingElse Create(string value);
    }
    
    public class DoSomethingElseFactory : IDoSomethingElseFactory
    {
        public IDoSomethingElse Create(string value)
        {
            // Every call to this method will create a new instance
            return new DoSomethingElse(value);
        }
    }
    
    public class FooController : ApiController
    {
        private IDb db;
        private readonly IDoSomethingElseFactory doSomethingElseFactory;
    
        public FooController (
            IDb context,
            IDoSomethingElseFactory doSomethingElseFactory)
        {
            db = context;
            this.doSomethingElseFactory = doSomethingElseFactory;
        }
    
        public void DoSomething(string value)
        {
            // this will be the point at which a brand new
            // instance of `DoSomethingElse` will be created.
            var output = doSomethingElseFactory.Create(value);
        }
    }
