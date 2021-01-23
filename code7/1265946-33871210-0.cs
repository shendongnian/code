    void Main()
    {
    	var a = new A(){ Name = "A" };
    	var b = new B(){ Name = "B" };
    	
    	INameProvider provider = new BNext(b);	
    	//...	
    }
    
   	//original classes	
    public class A{
    
    	public string Name { get; set; }
    }
    
    public class B{
    
    	public string Name { get; set; }
    	public string Id { get; set; }
    }
    
    //common interface
    public interface INameProvider {
    	string Name { get; set; }
    }
    
    //adapters
    public class ANext : A, INameProvider 
    {
    	public ANext(A a)
    	{
    		this.Name = a.Name;		
    	}
    }
    
    public class BNext : B, INameProvider 
    {
    	public BNext(B b)
    	{
    		this.Name = b.Name;
    		this.Id = b.Id;
    	}
    }
