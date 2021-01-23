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
    
    			// works
    			var typeofFoo = typeof(Foo);
    			var foo = proxy.GetFoo(new TypeDef() { Asembly = typeofFoo.Assembly.FullName, FullTypeName = typeofFoo.FullName });
    			Console.WriteLine(foo.Domain);
    
    			// Type also implements Serializable attribute (my mistake, I thought it did not)
    			foo = proxy.GetFoo(typeofFoo);
    			Console.WriteLine(foo.Domain);
    
    			Console.WriteLine();
    			Console.WriteLine("ENTER to exit");
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
    		IFoo GetFoo(TypeDef typeToGet);
    		IFoo GetFoo(Type type);
    	}
    	[Serializable]
    	public class TypeDef
    	{
    		public string Asembly { get; set; }
    		public string FullTypeName { get; set; }
    	}
    
    	public class Proxy : MarshalByRefObject, IProxy
    	{
    		public IFoo GetFoo(TypeDef typeToGet)
    		{
    			var type = Type.GetType(typeToGet.FullTypeName + ", " + typeToGet.Asembly, true);
    			var instance = Activator.CreateInstance(type) as IFoo;
    			return instance;
    		}
    		public IFoo GetFoo(Type type)
    		{
    			var instance = Activator.CreateInstance(type) as IFoo;
    			return instance;
    		}
    	}
    }
