    [DllImport(@"C:\Program Files\MATLAB\MATLAB Compiler Runtime\v80\runtime\win64\mclmcrrt8_0.dll", EntryPoint = "mclGetLastErrorMessage_proxy", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, ExactSpelling = true)]
    private static extern IntPtr _mclGetLastErrorMessage();
    public static String mclGetLastErrorMessage()
    {
	    var ptr = _mclGetLastErrorMessage(); 
		return Marshal.PtrToStringAnsi(ptr);
    }
