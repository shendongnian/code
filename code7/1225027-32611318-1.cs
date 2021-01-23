    class Program
    {
        const string DLLNAME = "CppLib.dll";
        static void Main(string[] args)
        {
            var sb = new StringBuilder(256).Append("Hello from C#");
            GetString(sb, sb.Capacity);
            Console.WriteLine("String from Dll is {0}", sb);
        }
        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void GetString(StringBuilder pBuff, int size);
    }
