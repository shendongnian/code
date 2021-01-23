    public void Main()
    {
        this.YourAction("foo", "bar").Dump();
        this.YourAction("foo", "baz").Dump();
    }
    
    public string YourAction(string firstParameter, string secondParameter)
    {
        return Dispatcher.Dispatch(firstParameter, secondParameter);
    }
    
    public static class Dispatcher
    {
        private readonly static ICollection<Handler> Handlers = new List<Handler>();
        
        static Dispatcher()
        {
            Handlers.Add(new FooHandler());
            Handlers.Add(new BarHandler());
        }
    
        public static string Dispatch(string firstParameter, string secondParameter)
        {
            return
                Handlers
                .Single(a => a.CanHandle(firstParameter, secondParameter))
                .Handle(firstParameter, secondParameter);
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
