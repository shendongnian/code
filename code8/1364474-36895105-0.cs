    public interface Interface<T> { void Method(T t); }
    
    public class ImplementedInterface : Interface<string> { void Interface<string>.Method(string t) { } }
    
    void Main()
    {
    	dynamic i = (Interface<string>)new ImplementedInterface();
    
    	i.Method(); // throws exception as method is not found.
    }
