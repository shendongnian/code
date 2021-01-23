    [DllImport("testDll.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
    public static extern IntPtr Test_EchoStringNew(string foo);
    [DllImport("testDll.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
    public static extern void Test_EchoStringDelete();
    public void foo()
    {
        string result = Marshal.PtrToStringAuto(Test_EchoStringNew("test"));
        MessageBox.Show(result.ToString());
        Test_EchoStringDelete();
    }
