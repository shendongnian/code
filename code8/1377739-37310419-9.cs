    internal static class ComponentEnvironment
    {
    	internal static void Prepare()
    	{	
    		CopyFilesAndDeps();
    	
    		if (Environment.Is64BitOperatingSystem) 
    			RegSvr64();
    		RegSvr32(); //you may notice no "else" here
    		//in my case for 64 bit I had to copy and register files for both arch 
    	}
    
    	#region unpack and clean files
    
    	private static void CopyFilesAndDeps()
    	{
    		//inspect what file you need
    	}
    
    	#endregion unpack and clean files
    
    	#region register components
    
    	private static void RegSvr32()
    	{
    		string dllPath = @"xxx\x86\xxx.dll";
    		Process.Start("regsvr32", "/s " + dllPath);
    	}
    
    	private static void RegSvr64()
    	{
    		string dllPath = @"xxx\x64\xxx.dll";
    		Process.Start("regsvr32", "/s " + dllPath);
    	}
    
    	#endregion register components
    }
