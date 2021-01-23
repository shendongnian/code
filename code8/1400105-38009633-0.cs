	class call_dll
	{
		[DllImport("my.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int myfunc(
			[MarshalAs(UnmanagedType.LPWStr)] string aTitle,
			[MarshalAs(UnmanagedType.LPStr)]  string aMessage);
	}
	
