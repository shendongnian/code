    public class FooController : ApiController
    {
       private IDb db;
        public FooController (IDb context)
        {
            db = context;
        }
    
        public void DoSomething(string value)
        {
            var output = new DoSomethingElse(value);
        }
    }
