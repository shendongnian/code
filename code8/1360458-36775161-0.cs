    using System;
    using Autofac;			
    
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("Hello World");
    		
    		var builder = new ContainerBuilder();
    		
    		builder.RegisterGeneric(typeof(LoggerService<>))
    			   .As(typeof(ILogger<>))
    			   .InstancePerLifetimeScope();
    		
    		var container = builder.Build();
    		
    		var obj = container.Resolve<ILogger<MyService>>();
    		var obj2 = container.Resolve<ILogger<OtherService>>();
    		
    		Console.WriteLine(obj.Log());
    		Console.WriteLine(obj2.Log());
    	}
    }
    
    public interface ILogger<T>
    {
    	string Log();
    }
    
    public class LoggerService<T> : ILogger<T>
    {
    	public string Log()
    	{
    		return typeof(T).Name;
    	}
    }
    
    public class MyService
    {
    	
    }
    
    public class OtherService
    {
    	
    }
