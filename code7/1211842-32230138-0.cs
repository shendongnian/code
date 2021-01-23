    static class NativeMethods
    {  
        
        // To  load dll
        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);
        // To get the Address of the Function
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);
        // Freeing up the Library for other usage. 
        [DllImport("kernel32.dll")]
        public static extern bool FreeLibrary(IntPtr hModule);
    }
    class manageCAN
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        // Declaration of function to get
        private delegate int CAN_Initial(int baudRate);
        private delegate int Library_Release();
        // Getting the String for .dll Address
        static readonly string dllfile = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\VTC1010_CAN_Bus.dll";
        
        public int IntialiseCAN (int baudrate)
        {
            // Loading dll using Native Methods
            IntPtr pDll = NativeMethods.LoadLibrary(dllfile);
            if (pDll== IntPtr.Zero)
            {
                MessageBox.Show("Loading Failed");
            }   
            // Getting the Adress method
            IntPtr pAddressOfFunctionToCall = NativeMethods.GetProcAddress(pDll, "CAN_Initial");
            CAN_Initial initialiseCAN = (CAN_Initial)Marshal.GetDelegateForFunctionPointer(pAddressOfFunctionToCall, typeof(CAN_Initial));
            int result = initialiseCAN(baudrate);
            bool iresult = NativeMethods.FreeLibrary(pDll);
            return result;
        }
    }
