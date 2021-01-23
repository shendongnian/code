        [DllImport("HelloCppLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr HelloFromCPP();
        public static void Main(string[] args)
        {
            Console.WriteLine( Marshal.PtrToStringAnsi(HelloFromCPP()) );
