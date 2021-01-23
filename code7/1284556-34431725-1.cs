    void Main()
    {
    	PrimitiveConclusion<int> primitiveConclusion = new PrimitiveConclusion<int>(1);
    	Conclusion<ParseResult> parseResultConclusion = new Conclusion<ParseResult>(new ParseResult {});
    
    	Console.WriteLine($"{primitiveConclusion.Result.GetType()}");
    	Console.WriteLine($"{parseResultConclusion.Result.GetType()}");
    }
    
    public class TestClass
    {
    	public Conclusion<ParseResult> ParseInput(string input)
    	{
    		return new Conclusion<ParseResult>(null);
    	}
    }
    
    public interface IConcludable { }
    
    public abstract class AbstractConclusion<T>
    {
    	public AbstractConclusion(T t)
    	{
    		IsSuccessful = t != null;
    		Result = t;
    	}
    	public bool IsSuccessful;
    	public T Result;
    }
    
    public class Conclusion<T> : AbstractConclusion<T> where T : IConcludable
    {
    	public Conclusion(T t) : base(t)
    	{
    	}
    }
    
    
    public class PrimitiveConclusion<T> : AbstractConclusion<T> where T : struct
    {
    	public PrimitiveConclusion(T t) : base(t)
    	{
    	}
    }
    
    
    public class ParseResult : IConcludable { }
