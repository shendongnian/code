    public static class Platform
    {
    	[DllImport("kernel32.dll", SetLastError = true)]
    	[return: MarshalAs(UnmanagedType.Bool)]
    	static extern bool SetDllDirectory(string pathName) ;
    
    	public static void Setup()
    	{
    		if (Environment.Is64BitProcess)
    			SetDllDirectory("./x64/") ;
    		else // default Win32
    			SetDllDirectory("./x86/") ;
    	}
    }
