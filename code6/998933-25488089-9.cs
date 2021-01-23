    public static class ManagementObjectExtensions
    {
    	const string WQL_DEVICE = "Select Size,FreeSpace from Win32_LogicalDisk where Deviceid='{0}'";
    	const string WQL_FOLDER = "Select Path, Filename, Name from CIM_Directory where Drive='{0}' and path='\\\\' and system = false and hidden = false and readable = true";
    	const string WQL_SUBFOLDER = "Select Path, Filename from CIM_Directory where Drive='{0}' and path like '{1}{2}\\\\%' and system = false and hidden = false and readable = true";
    	const string WQL_FILE = "Select FileSize from CIM_DataFile where Drive='{0}' AND Path = '{1}{2}\\\\' ";
    
        // internal helper to get an enumerable collection from any WQL
    	private static ManagementObjectCollection GetWqlEnumerator(this ManagementScope scope, string wql, params object[] args)
    	{
    		return new ManagementObjectSearcher(
    			scope,
    			new ObjectQuery(
    				String.Format(wql, args)))
    			.Get();
    	}
    
    	public static ManagementObjectCollection Device(this ManagementScope scope, params object[] args)
    	{
    		return scope.GetWqlEnumerator(WQL_DEVICE, args);
    	}
    
    	public static ManagementObjectCollection Folder(this ManagementScope scope, params object[] args)
    	{
    		return scope.GetWqlEnumerator(WQL_FOLDER, args);
    	}
    
    	public static ManagementObjectCollection SubFolder(this ManagementScope scope, params object[] args)
    	{
    		return scope.GetWqlEnumerator(WQL_SUBFOLDER, args);
    	}
    
    	public static ManagementObjectCollection File(this ManagementScope scope, params object[] args)
    	{
    		return scope.GetWqlEnumerator(WQL_FILE, args);
    	}
    
    	public static string Path(this ManagementBaseObject mo)
    	{
    		return mo["Path"].ToString().Replace("\\","\\\\");
    	}
    
    	public static string Name(this ManagementBaseObject mo)
    	{
    		return mo["Name"].ToString();
    	}
    
    	public static string FileName(this ManagementBaseObject mo)
    	{
    		return mo["FileName"].ToString();
    	}
    
    	public static ulong FreeSpace(this ManagementBaseObject mo)
    	{
    		return (ulong)mo["FreeSpace"];
    	}
    
    	public static ulong Size(this ManagementBaseObject mo)
    	{
    		return (ulong) mo["Size"];
    	}
    
    	public static ulong FileSize(this ManagementBaseObject mo)
    	{
    		return (ulong) mo["FileSize"];
    	}
    }
