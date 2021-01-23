    using System;
    using Ninject;
    
    namespace NinjectTest
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			IKernel kernel = new StandardKernel();
    
    			kernel.Bind<IInnerService>().ToMethod(c=>new InnerService("this is a test config key")); //bind InnerService implementation to be used with provided string
    			kernel.Bind<IOuterService>().To<OuterService>(); //bind OuterService implementation to be used, all parameters will be injected to it using previously defined configs
    
    			var outerService = kernel.Get<IOuterService>();
    
    			var result = outerService.CallInner();
    
    			Console.WriteLine(result);
    			Console.ReadLine();
    		}
    
    		public interface IInnerService
    		{
    			string GetConfigKey();
    		}
    
    		public class InnerService : IInnerService
    		{
    			private readonly string _configurationKey;
    
    			public InnerService(string configurationKey)
    			{
    				_configurationKey = configurationKey;
    			}
    
    			public string GetConfigKey()
    			{
    				return _configurationKey;
    			}
    		}
    
    		public class OuterService : IOuterService
    		{
    			private readonly IInnerService _innerService;
    
    			public OuterService(IInnerService innerService)
    			{
    				_innerService = innerService;
    			}
    
    			public string CallInner() //purely for testing
    			{
    				return _innerService.GetConfigKey();
    			}
    		}   
    
    		public interface IOuterService
    		{
    			string CallInner();
    		}
    	}
    }
