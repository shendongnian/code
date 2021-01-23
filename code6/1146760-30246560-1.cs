	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Reflection;
	using System.Text;
	using System.Threading.Tasks;
	namespace ConsoleApplication1
	{
		class Program
		{
			static void Main(string[] args)
			{
				try
				{
					String pathToAssembly = args[0];
					AppDomain dom = AppDomain.CreateDomain("some");
					AssemblyName assemblyName = new AssemblyName();
					assemblyName.CodeBase = "loader.dll";
					dom.Load(assemblyName);
					object loader = dom.CreateInstanceAndUnwrap("loader", "loader.AsmLoader");
					Type loaderType = loader.GetType();
					loaderType.GetMethod("LoadAssembly").Invoke(loader, new object[] { pathToAssembly });                
					//make sure the given assembly is not loaded in the main app domain and thus would be locked
					AppDomain.CurrentDomain.GetAssemblies().All(a => { Console.WriteLine(a.FullName); return true; });
					AppDomain.Unload(dom);
					GC.Collect();
					GC.WaitForPendingFinalizers();
					GC.Collect();
					File.Delete(pathToAssembly);
				}
				catch(Exception ex)
				{
					Console.WriteLine(ex.ToString());
				}
			}
		}
	}
