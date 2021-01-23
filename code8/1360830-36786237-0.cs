    public class Program
    {
    	public static void Main()
    	{
    		
    	}
    	
    	public string ABC(IDestination destination)
    	{
    		return destination.DoSomething();	
    	}
    	
    }
    
    public class ClassA: IDestination
    {
    	public string Var1 { get; set; }    
    	public string Var2 { get; set; }    
    	public string Var3 { get; set; }
    	
    	public string DoSomething()
    	{
    		return Var2;		
    	}
    }
    
    public class ClassB: IDestination
    {
    	public string Var1 { get; set; }
    	public string Var2 { get; set; }
    	public string Var3 { get; set; }
    	public string Var4 { get; set; }
    	public string Var5 { get; set; }
    	
    	public string DoSomething()
    	{
    		return Var4;		
    	}
    }
    
    public interface IDestination
    {
    	string Var1 { get; set; }
    	string Var2 { get; set; }
    	string DoSomething();
    }
