    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SomeStruct
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string stringBuffer;
        public UInt64 size;
        public Int64 mTime;
    };
    [DllImport("Win32Project1.dll", EntryPoint = "GetSomeStructures")]
    static extern int GetSomeStructures(
            uint index, ref SomeStruct str, ulong stringBufferSize);
    static void Main(string[] args)
    {
        var a = new SomeStruct(){
            stringBuffer = "asd",
            size=10,
            mTime = 20
        };
        Console.WriteLine(GetSomeStructures(1, ref a, 1));
    }
