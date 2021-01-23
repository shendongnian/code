    //classes used as markers
    public interface IMarker {}
    public class MarkerA : IMarker {}
    public class MarkerB : IMarker {}
    
    //classes to be created
    public interface IData {}
    public class DataA : IData {}
    public class DataB : IData {}
    
    //factory to call abstract factories (could use static here)
    public class Factory
    {
    	public IData Create(IMarker marker)
    	{
    		//lookup dictionary instead of if/switch
    		//func ensures instance is only created when required
    		var lookup = new Dictionary<Type, Func<DataFactoryBase>>()
    		{
    			{ typeof(MarkerA), () => new DataAFactory() },
    			{ typeof(MarkerB), () => new DataBFactory() },
    		};
    		
    		//get factory by type and call constructor
    		return lookup[marker.GetType()]().Create();
    	}
    }
    
    //abstract factories
    public abstract class DataFactoryBase
    {
    	public abstract IData Create();
    }
    
    public class DataAFactory : DataFactoryBase
    {
    	public override IData Create()
    	{
    		return new DataA();
    	}
    }
    
    public class DataBFactory : DataFactoryBase
    {
    	public override IData Create()
    	{
    		return new DataB();
    	}
    }
    
    
    public static void Main()
    {
    	//example will return DataA	
    	IData data = new Factory().Create(new MarkerA());	
    }
