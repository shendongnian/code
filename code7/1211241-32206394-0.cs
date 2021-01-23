    class manageCAN
    {
        // Getting the String for .dll Address
        string dllfile = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\VTC1010_CAN_Bus.dll";
        // Loading dll using Native Methods
        IntPtr pDll;
        public manageCAN()
        {
            pDll = NativeMethods.LoadLibrary(dllfile);
        }
    }
