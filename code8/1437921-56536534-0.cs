    public interface IService { }
    public class ServiceA : IService
    {
    	public override string ToString()
    	{
    		return "A";
    	}
    }
    
    public class ServiceB : IService
    {
    	public override string ToString()
    	{
    		return "B";
    	}
    
    }
    
    /// <summary>
    /// extension method that compares with ToString value of an object and returns an object if found
    /// </summary>
    public static class ServiceProviderServiceExtensions
    {
    	public static T GetService<T>(this IServiceProvider provider, string identifier)
    	{
    		var services = provider.GetServices<T>();
    		var service = services.FirstOrDefault(o => o.ToString() == identifier);
    		return service;
    	}
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
    	//Initials configurations....
    
    	services.AddSingleton<IService, ServiceA>();
    	services.AddSingleton<IService, ServiceB>();
    	services.AddSingleton<IService, ServiceC>();
    
    	var sp = services.BuildServiceProvider();
    	var a = sp.GetService<IService>("A"); //returns instance of ServiceA
    	var b = sp.GetService<IService>("B"); //returns instance of ServiceB
    
    	//Remaining configurations....
    }
