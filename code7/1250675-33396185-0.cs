    private const string DLLPATH = "MyDLL.dll";
    [DllImport(DLLPATH, EntryPoint = "GetDLLStatus")]
    public static extern int GetDLLStatus();
    [DllImport(DLLPATH, EntryPoint = "SomeOtherFunction")]
    public static extern float SomeOtherFunction();
