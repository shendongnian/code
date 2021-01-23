    public static void ObjectToString(out string buffer, Comarea comarea)
    {
        int size = 0;
        IntPtr pBuf = IntPtr.Zero;
    
        try
        {
            size = Marshal.SizeOf(comarea);
            pBuf = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(comarea, pBuf, false);
            buffer = Marshal.PtrToStringAuto(pBuf, size); // Answer
        }
        catch
        {
            throw;
        }
        finally
        {
            Marshal.FreeHGlobal(pBuf);
        }
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct Comarea
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        private char[] status;
    
        public string Status
        {
            get
            {
                return new string(status);
            }
    
            set
            {
                status = value.ToCharArray();
            }
        }
    
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        private char[] operationName;
    
        public string OperationName
        {
            get
            {
                return new string(operationName);
            }
    
            set
            {
                operationName = value.ToCharArray();
            }
        }
    }
