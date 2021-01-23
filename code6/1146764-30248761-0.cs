    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Reflection;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Diagnostics;
    using System.Security.Policy;
    using System.Security;
    using System.Security.Permissions;
    using System.Configuration;
    
    class Program
    {
    	public static void Main(string[] args)
    	{
    		String pathToAssembly = args[0];
    		AppDomain dom = AppDomain.CreateDomain("some");     
    		AssemblyName assemblyName = new AssemblyName();
    		assemblyName.CodeBase = pathToAssembly;
    		Assembly assembly = dom.Load(assemblyName);
    		AppDomain.Unload(dom);
    		GC.Collect();
    		GC.WaitForPendingFinalizers();
    		GC.Collect();
    		File.Delete(pathToAssembly);
    	}
    }
