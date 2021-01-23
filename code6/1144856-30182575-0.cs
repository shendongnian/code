    /// <summary>
    /// Respect the order of the scripts added
    /// </summary>
    public class NonOrderingBundleOrderer : IBundleOrderer
    {
    	public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
    	{
    		return files;
    	}
    }
