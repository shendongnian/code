    public interface IFooService
    {
        void DoSomethingFooey();
    }
    public class FooService : IFooService
    {
        readonly IBarService _barService;
    
        public FooService() : this(new BarService()) {}
    
        public FooService(IBarService barService)
        {
            this._barService = barService;
        }
    
        public void DoSomethingFooey()
        {
            // some stuff
            _barService.DoSomethingBarey();
        }
    }
    
    
    public interface IBarService
    {
        void DoSomethingBarey();
    }
    public class BarService : IBarService
    {
        readonly IBazService _bazService;
    
        public BarService() : this(new BazService()) {}
    
        public BarService(IBazService bazService)
        {
            this._bazService = bazService;
        }
    
        public void DoSomethingBarey()
        {
            // Some more stuff before doing ->
            _bazService.DoSomethingBazey();
        }
    }
    
    
    public interface IBazService
    {
        void DoSomethingBazey();
    }
    public class BazService : IBazService
    {
        public void DoSomethingBazey()
        {
            Console.WriteLine("Blah blah");
        }
    }
