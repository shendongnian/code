    public interface IBaseClass
    {
    	public string GetProperty1();
        public string GetProperty2();
        public string GetProperty3();
    }
    
    public interface IC1
    {
        public string GetProperty4();
    }
    
    public interface IC2
    {
        public string GetProperty5();
    }
    
    
    public class Implementation : IBaseClass, IC1, IC2
    {
    	public string GetProperty1()
    	{
    		return "Value";
    	}
    	public string GetProperty2()
    	{
    		return "Value";
    	}
    	public string GetProperty3()
    	{
    		return "Value";
    	}
    	public string GetProperty4()
    	{
    		return "Value";
    	}
    	public string GetProperty5()
    	{
    		return "Value";
    	}
    	
    	
    }
