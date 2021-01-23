    <#@ assembly name="Microsoft.VisualStudio.Shell.Interop.8.0" #>
    <#@ assembly Name="EnvDTE" #>
    <#@ import namespace="System.IO" #>
    <#@ import namespace="System.Reflection" #>
    <#@ import namespace="System.Diagnostics" #>
    <#@ import namespace="EnvDTE" #>
    <#@ import namespace="Microsoft.VisualStudio.Shell.Interop" #>
    <#@ import namespace="Microsoft.VisualStudio.TextTemplating" #>
    <#+
    
        public class CodeGenHelpers
        {
            private static string _ConfigName;
    		private static bool? _ShouldRegenerate;
            private ITextTemplatingEngineHost _Host;
            private static DTE _Dte;
    
            public CodeGenHelpers(ITextTemplatingEngineHost host)
            {
                _Host = host;
            }
    
            public  bool ShouldRegenerate()
            {
                if (_ShouldRegenerate.HasValue == false)
                {
    				var configName = GetConfigName();   
    				_ShouldRegenerate = "RegenCodeFiles".Equals(configName, StringComparison.OrdinalIgnoreCase);
                }
    
                return _ShouldRegenerate.Value;
            }
    
            public string GetConfigName()
            {
                if (string.IsNullOrWhiteSpace(_ConfigName))
                {
                    _ConfigName = GetDte().Solution.SolutionBuild.ActiveConfiguration.Name;
                }
                return _ConfigName;
    		}
    
            public DTE GetDte()
            {
                if (_Dte == null)
                {
                    var serviceProvider = _Host as IServiceProvider;
                    _Dte = serviceProvider.GetService(typeof(SDTE)) as DTE;
                }
                return _Dte;
            }
    
            public void SetupBinPathAssemblyResolution()
            {
                AppDomain.CurrentDomain.AssemblyResolve += ResolveMeh;
            }
    
    		//load from nuget packages first
    		public Assembly ResolveMeh(object sender, ResolveEventArgs args)
    		{
    			var currentFolder = new FileInfo(_Host.ResolvePath(_Host.TemplateFile)).DirectoryName;
    			var configName = GetConfigName();
    			//probably look at the project properties in DTE, but whatever
    		    var d = _Dte;
    			var assemblyName = new AssemblyName(args.Name).Name + ".dll";
    			var assemblyLoadFolder = Path.Combine(currentFolder, $"bin\\{configName}");
    			var assemblyPath = Path.Combine(assemblyLoadFolder, assemblyName);
    			if (System.IO.File.Exists(assemblyPath) == true) 
    			{
    				var assembly = Assembly.LoadFrom(assemblyPath);
    				return assembly;
    			}
    
    			//there are nuget services for vs, but they are installed via nuget package, 
    			// which is what this is looking for so I dont know if it will work. 
    			// https://www.nuget.org/packages/NuGet.VisualStudio
    
    
    		    var solutionFilePath = GetDte().FullName;
    		    var solutionFile = GetDte().FileName;
    		    var solutionFolder = solutionFilePath.Replace(solutionFile, string.Empty);
    		    var packagesFolder = System.IO.Path.Combine(solutionFolder, "packages");
    		    var files = System.IO.Directory.GetFiles(packagesFolder, assemblyName, SearchOption.AllDirectories);
    		    if (files.Length > 0)
    		    {
    				var assembly = Assembly.LoadFrom(files[0]); //prob also check target fw
    				return assembly;
    		    }
    			
    		    return null;
    		}
    
        }
    
    #>
