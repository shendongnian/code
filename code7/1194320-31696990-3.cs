    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
    public delegate void myCallback(string toShow);
    [DllImport("testDll.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
    public static extern void Test_EchoString(string foo, myCallback callback);
    public void foo()
    {
        Test_EchoString("test", callback);
    }
    void callback(string toShow)
    {
        MessageBox.Show(toShow);
    }
