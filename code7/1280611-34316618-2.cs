    public void Main()
    {
        Console.WriteLine(this.YourAction("foo", "bar"));
        Console.WriteLine(this.YourAction("foo", "baz"));
    }
    
    public string YourAction(string firstParameter, string secondParameter)
    {
        var handler = Dispatcher.GetHandler(firstParameter, secondParameter);
    
        if (handler == null)
        {
            throw new Exception("I don't know what to do.");
        }
        
        return handler.Handle(firstParameter, secondParameter);
    }
    
    public static class Dispatcher
    {
        private readonly static ICollection<Handler> Handlers = new List<Handler>();
    
        static Dispatcher()
        {
            Handlers.Add(new FooHandler());
            Handlers.Add(new BarHandler());
        }
    
        public static Handler GetHandler(string firstParameter, string secondParameter)
        {
            // Yes, Single, not First. If you screw up and two handlers can handle
            // the same parameters set you want to know it up front, not later.
            return Handlers.SingleOrDefault(a => a.CanHandle(firstParameter, secondParameter));
        }
    }
    
    public abstract class Handler
    {
        public abstract bool CanHandle(string firstParameter, string secondParameter);
    
        public abstract string Handle(string firstParameter, string secondParameter);
    }
    
    public class FooHandler : Handler
    {
        public override bool CanHandle(string firstParameter, string secondParameter)
        {
            return firstParameter == "foo" && secondParameter == "bar";
        }
    
        public override string Handle(string firstParameter, string secondParameter)
        {
            return "FooAction";
        }
    }
    
    public class BarHandler : Handler
    {
        public override bool CanHandle(string firstParameter, string secondParameter)
        {
            return firstParameter == "foo" && secondParameter == "baz";
        }
    
        public override string Handle(string firstParameter, string secondParameter)
        {
            return "BarAction";
        }
    }
