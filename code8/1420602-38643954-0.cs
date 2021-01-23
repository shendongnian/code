    using System;
    using System.Reflection;
    
    namespace AppdomainTesting
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var p = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    			var setup = new AppDomainSetup()
    			{
    				ApplicationBase = p
    			};
    			IProxy proxy;
    			var domain = AppDomain.CreateDomain("MyTest_AppDomain", AppDomain.CurrentDomain.Evidence, setup);
    				var t = typeof(Proxy);
    			proxy = domain.CreateInstanceAndUnwrap(t.Assembly.FullName,
    				t.FullName,
    				false,
    				BindingFlags.Default,
    				null,
    				null,
    				null,
    				null) as IProxy;
    
    			var foo = proxy.GetFoo();
    
    			Console.WriteLine(foo.Domain);
    
    			Console.ReadLine();
    		}
    	}
    
    	public interface IFoo
    	{
    		string Domain { get; }
    	}
    
    	public class Foo : MarshalByRefObject, IFoo
    	{
    		public string Domain
    		{
    			get { return System.AppDomain.CurrentDomain.FriendlyName; }
    		}
    	}
    	public interface IProxy
    	{
    		IFoo GetFoo();
    	}
    
    	public class Proxy : MarshalByRefObject, IProxy
    	{
    		public IFoo GetFoo()
    		{
    			// AppdomainTesting is the name of the console project (assembly)
    			var type = Type.GetType("AppdomainTesting.Foo, AppdomainTesting", true);
    			var instance = Activator.CreateInstance(type) as IFoo;
    			return instance;
    		}
    	}
    }
