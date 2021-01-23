    [DllImport("example.dll", EntryPoint = "consume_ptr", CallingConvention = CallingConvention.Cdecl)]
    private static extern void consume_ptr(int arg);
    static void Main(string[] args)
    {
        consume_ptr(0);
    }
