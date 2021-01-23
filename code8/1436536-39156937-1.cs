    namespace ConsoleApplicationGrbage
    {
    class Program
    {
    	static void Main(string[] args)
    	{
    		var container = new UnityContainer();
    
    		var list = new Dictionary<string, string>();
    		list.Add("NameA", "YourClass");
    		
    		var thisAssemebly = Assembly.GetExecutingAssembly();
    		var exT = thisAssemebly.ExportedTypes;
    		//register types only that are in the dictionary
    		foreach (var item in list)
    		{
    			var typeClass = exT.First(x => x.Name == item.Value);
    			var ivmt = Type.GetType("ConsoleApplicationGrbage.IYourInterface");
    			// --> Map Interface to ImplementationType
    			container.RegisterType(ivmt, typeClass, item.Key);
    			// or directly:
    			container.RegisterType(typeof(IYourInterface), typeClass, item.Key);	
    		}
    
    		var impl = container.Resolve<IYourInterface>("NameA");
    	}
    }
    	
    
    public interface IYourInterface
    {
    }
    
    public class YourClass: IYourInterface
    {
    
    }
    
    }
