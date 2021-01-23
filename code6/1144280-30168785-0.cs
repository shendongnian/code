    public struct ads_name
    {
        public IntPtr a;
        public IntPtr b;
    };
    
    [DllImport("acad.exe", CallingConvention = CallingConvention.Cdecl]
    static extern IntPtr acdbEntGet(ads_name objName);
