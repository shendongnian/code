    public class MyDllhelper
    {
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct Info
        {
            public ushort port;
            public ushort flag;
            public fixed byte name[16];
            public unsafe string Name
            {
                get
                {
                    fixed (byte* ptr = name)
                    {
                        IntPtr ptr2 = (IntPtr)ptr;
                        return Marshal.PtrToStringAnsi(ptr2, 16).TrimEnd('\0');
                    }
                }
                set
                {
                    fixed (byte* ptr = name)
                    {
                        IntPtr ptr2 = (IntPtr)ptr;
                        byte[] bytes = Encoding.ASCII.GetBytes(value);
                        int length = Math.Min(15, bytes.Length);
                        Marshal.Copy(bytes, 0, ptr2, length);
                        ptr[length] = 0;
                    }
                }
            }
        }
        public VoidRefInfoDelegate C { get; set; }
        public VoidRefInfoDelegate Timeout { get; set; }
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void VoidRefInfoDelegate(ref Info info);
        [DllImport("MyDLL", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr open(ref Info info, VoidRefInfoDelegate c, VoidRefInfoDelegate timeout);
        public IntPtr Open(ref Info info, VoidRefInfoDelegate c, VoidRefInfoDelegate timeout)
        {
            C = c;
            Timeout = timeout;
            return open(ref info, C, Timeout);
        }
    }
