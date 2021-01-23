    class Program
    {
        [DllImport("kernel32", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, EntryPoint = "LoadLibraryW", ExactSpelling = true, SetLastError = true)]
        static extern IntPtr LoadLibrary(string lpFileName);
        [DllImport("kernel32", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string procName);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        delegate IntPtr PluginGetter();
        static void Main(string[] args)
        {
            IntPtr hmod = LoadLibrary("in_midi.dll");
            if (hmod == IntPtr.Zero)
            {
                throw new Win32Exception();
            }
            IntPtr proc = GetProcAddress(hmod, "winampGetInModule2");
            if (proc == IntPtr.Zero)
            {
                throw new Win32Exception();
            }
            PluginGetter getmod = (PluginGetter)Marshal.GetDelegateForFunctionPointer(proc, typeof(PluginGetter));
            
            IntPtr modptr = getmod();
            if (modptr == IntPtr.Zero)
            {
                throw new Win32Exception();
            }
            Console.WriteLine("Success");
        }
    }
