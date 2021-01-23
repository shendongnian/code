    public sealed class TargetClass{
    	public static readonly TargetClass tc = new TargetClass();
    	public int Id;
    	public string SomeName;
    	private TargetClass(){
    		this.Id=50;
    		this.SomeName="My, What Bastardry";
    	}
    }
    public class ProxyClass{
    	public int Id {get; set;}
    	public string SomeName {get; set;}
    	public ProxyClass(){
    	}
    	public ProxyClass(int id, string somename){
    		Id = id;
    		SomeName = somename;
    	}
    }
    public class Program
    {
    	public static void Main()
    	{
    		TargetClass tgt = TargetClass.tc;
    		ProxyClass pc = new ProxyClass(tgt.Id,tgt.SomeName);
    		string s = JsonConvert.SerializeObject(pc);
    		Console.WriteLine(s);
    	}
    }
