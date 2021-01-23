    using System;
	using System.Reflection;
	class ExampleClass
	{
	    static void Main()
	    {
	        AppDomain ad = AppDomain.CurrentDomain;
	        ad.AssemblyResolve += MyAssemblyResolveHandler;
			Assembly assembly = ad.Load("Assembly3.dll");
			Type type = assembly.GetType("Assembly3.Class1");
	        try
	        {
	            object instance = Activator.CreateInstance(type);
	        } 
	        catch (Exception ex)
	        {
	            Console.WriteLine(ex.Message);
	        }
	    }
	    static Assembly MyAssemblyResolveHandler(object source, ResolveEventArgs e) 
	    {
	    	// Assembly.LoadFrom("Assembly1.dll")
			// Assembly.LoadFrom("Assembly2.dll")
	        return Assembly.Load(e.Name);
	    }
	}
