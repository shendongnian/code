    public interface B<T> where T : A
    {
       T a {get; set;}
    }
    
    public class ConcreteA : A
    {
    }
    
    public class ConcreteB : B<ConcreateA>
    {
       public ConcreteA a {get; set;}
    }
