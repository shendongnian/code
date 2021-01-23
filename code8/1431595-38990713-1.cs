    using System;
    using System.Linq;
    using DryIoc;
    
    namespace DryIoc_example
    {
    	public interface IService {}
    	class ServiceImpl_1 : IService {}
    	class ServiceImpl_2 : IService {}
    
    	public class Program
    	{
    		public static void Main()
    		{
                    var container = new Container();
    
                    container.Register<IService, ServiceImpl_1>();
                    container.Register<IService, ServiceImpl_2>();
    			
    				var myService = container.TryResolveByImplementation<IService>(typeof(ServiceImpl_1));
    			    
    
                    // this line is expected to print the type of ServiceImpl_2
                    Console.WriteLine(myService.GetType());
    		}
    	}
    	
    	public static class ContainerExtensions
    	{
    		public static TService TryResolveByImplementation<TService>(this IContainer container, Type implementationType)
    		{
    			var factory = container.GetAllServiceFactories(typeof(TService))
    				.FirstOrDefault(f => f.Value.ImplementationType == implementationType);
    			
    			return factory != null 
    				? container.Resolve<TService>(serviceKey: factory.Key) 
    				: default(TService);
    		}
    	}
    }
