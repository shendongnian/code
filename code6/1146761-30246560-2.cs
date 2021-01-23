	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	using System.Text;
	using System.Threading.Tasks;
	namespace loader
	{
		public class AsmLoader: MarshalByRefObject
		{
			public AsmLoader()
			{
			}
			public void LoadAssembly(string path)
			{
				AssemblyName n = new AssemblyName();
				n.CodeBase = path;
				AppDomain.CurrentDomain.Load(n);
			}
		}
	}
