    public interface IBar { }
    
    public class BarA : IBar  { }
    
    public class Foo
    {
        public IBar Bar { get; set; }
    }
