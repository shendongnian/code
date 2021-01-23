    using System;
    using DryIoc;
    namespace DryIoc_example
    {
    	interface IService {}
    	class ServiceImpl_1 : IService {}
    	class ServiceImpl_2 : IService {}
    
    	public class Program
    	{
    		public static void Main()
    		{
    			var container = new Container();
    			
    			container.RegisterMany<ServiceImpl_1>(nonPublicServiceTypes: true);
    			container.RegisterMany<ServiceImpl_2>(nonPublicServiceTypes: true);
    			
    			var myService = container.Resolve<IService>(typeof(ServiceImpl_2));
    			
    			// this line is expected to print the type of ServiceImpl_2
    			Console.WriteLine(myService.GetType());
    		}
    	}
    }
