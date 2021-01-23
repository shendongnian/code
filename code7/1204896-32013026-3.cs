    public interface IHasNumber 
    {
        int Number { get; }
    }
    
    public class A : IHasNumber 
    { 
        public int Number { get; set; } 
    }
    public class B : IHasNumber 
    { 
        public int Number { get; } 
    }
