    var rootPath = @"pathWhereNuGetPackagesAre";
    var logger = new Logger();
    
    List<Lazy<INuGetResourceProvider>> providers = new List<Lazy<INuGetResourceProvider>>();
    providers.AddRange(Repository.Provider.GetCoreV3());
    
    FindLocalPackagesResourceV2 findLocalPackagev2 = new FindLocalPackagesResourceV2(rootPath);
    var packageFound = findLocalPackagev2.GetPackages(logger, CancellationToken.None).FirstOrDefault();
    //found, but missing a lot of informations...
    
    var supportedFramework = new[] { ".NETFramework,Version=v4.6" };
    var searchFilter = new SearchFilter(true)
    {
    	SupportedFrameworks = supportedFramework,
    	IncludeDelisted = false
    };
    // The trick here is to put the local nuget path, not using the URL : https://api.nuget.org/v3/index.json
    PackageSource localSource = new PackageSource(rootPath);
    SourceRepository localRepository = new SourceRepository(localSource, providers);
    PackageSearchResource searchLocalResource = await localRepository
    	.GetResourceAsync<PackageSearchResource>();
    
    var packageFound3 = await searchLocalResource
    	.SearchAsync("Newtonsoft.Json", searchFilter, 0, 10, logger, CancellationToken.None);
    var thePackage = packageFound3.FirstOrDefault();
    // found but missing the assemblies property
    public class Logger : ILogger
    {
    	private List<string> logs = new List<string>();
    
    	public void LogDebug(string data)
    	{
    		logs.Add(data);
    	}
    
    	public void LogVerbose(string data)
    	{
    		logs.Add(data);
    	}
    
    	public void LogInformation(string data)
    	{
    		logs.Add(data);
    	}
    
    	public void LogMinimal(string data)
    	{
    		logs.Add(data);
    	}
    
    	public void LogWarning(string data)
    	{
    		logs.Add(data);
    	}
    
    	public void LogError(string data)
    	{
    		logs.Add(data);
    	}
    
    	public void LogInformationSummary(string data)
    	{
    		logs.Add(data);
    	}
    
    	public void LogErrorSummary(string data)
    	{
    		logs.Add(data);
    	}
    }
