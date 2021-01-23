	public class CodeGenerator
	{
		public static string BaseDirectory { get; set; }
		public static string BinDirectory { get; set; }
		
		static CodeGenerator()
		{
			BinDirectory = "bin";
            // setting this in a static constructor is best practice
			AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
		}
		
		public CodeGenerator(string entryAssemblyPath = null, string baseDirectory = null, string binDirectory = null)
		{
			if (string.IsNullOrWhiteSpace(baseDirectory))
				BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
			else
				BaseDirectory = baseDirectory;
			if (string.IsNullOrWhiteSpace(binDirectory) == false)
				BinDirectory = binDirectory;
				
			if (entryAssemblyPath == null) // running under the Asp.Net domain
				EntryAssembly = GetWebEntryAssembly(); // get the Asp.Net main assembly
			else
			{
				// manually load the assembly into the domain via a file path
				// e:\inetpub\wwwroot\myAspNetMVCApp\bin\myApp.dll
				EntryAssembly = Assembly.LoadFrom(entryAssemblyPath);
			}
			var areas = GetAreaRegistrations(); // reflect away!
			... code ...
		}
		
		static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
		{
			try
			{
				if (args == null || string.IsNullOrWhiteSpace(args.Name))
				{
					Logger.WriteLine("cannot determine assembly name!", Logger.LogType.Debug);
					return null;
				}
				AssemblyName assemblyNameToLookFor = new AssemblyName(args.Name);
				Logger.WriteLine("FullName is {0}", Logger.LogType.Debug, assemblyNameToLookFor.FullName);
				// don't load the same assembly twice!
				var domainAssemblies = AppDomain.CurrentDomain.GetAssemblies();
				var skipLoading = false;
				foreach (var dAssembly in domainAssemblies)
				{
					if (dAssembly.FullName.Equals(assemblyNameToLookFor.FullName))
					{
						skipLoading = true;
						Logger.WriteLine("skipping {0} because its already loaded into the domain", Logger.LogType.Error, assemblyNameToLookFor.FullName);
						break;
					}
				}
				if (skipLoading == false)
				{
					var requestedFilePath = Path.Combine(Path.Combine(BaseDirectory, BinDirectory), assemblyNameToLookFor.Name + ".dll");
					Logger.WriteLine("looking for {0}...", Logger.LogType.Warning, requestedFilePath);
					if (File.Exists(requestedFilePath))
					{
						try
						{
							Assembly assembly = Assembly.LoadFrom(requestedFilePath);
                            if (assembly != null)
								Logger.WriteLine("loaded {0} successfully!", Logger.LogType.Success, requestedFilePath);
							// todo: write an else to handle load failure and search various probe paths in a loop
							return assembly;
						}
						catch (FileNotFoundException)
						{
							Logger.WriteLine("failed to load {0}", Logger.LogType.Error, requestedFilePath);
						}
					}
					else
					{
						try
						{
							// ugh, hard-coding, but I need to get on with the real programming for now
							var refedAssembliesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5.1");
							requestedFilePath = Path.Combine(refedAssembliesPath, assemblyNameToLookFor.Name + ".dll");
							Logger.WriteLine("looking for {0}...", Logger.LogType.Warning, requestedFilePath);
							Assembly assembly = Assembly.LoadFrom(requestedFilePath);
                            if (assembly != null)
								Logger.WriteLine("loaded {0} successfully!", Logger.LogType.Success, requestedFilePath);
							// todo: write an else to handle load failure and search various probe paths in a loop
							return assembly;
						}
						catch (FileNotFoundException)
						{
							Logger.WriteLine("failed to load {0}", Logger.LogType.Error, requestedFilePath);
						}
					}
				}
			}
			catch (Exception e)
			{
				Logger.WriteLine("exception {0}", Logger.LogType.Error, e.Message);
			}
			return null;
		}
	}
