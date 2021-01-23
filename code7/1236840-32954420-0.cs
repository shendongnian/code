	// somewhere in your class
	[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl, SetLastError=true)]
	public static extern int system(string command);
	public static int Main(string[] argv)
	{
		// your code
		
		
		system("pause"); // will automaticly print the localized string and wait for any user key to be pressed
		return 0;
	}
