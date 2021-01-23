    [DllImport("NativeLibrary", CallingConvention = CallingConvention.Cdecl)]
    public static extern void get_string(StringFromIntPtr.FromIntPtrDelegate func);
    public class StringFromIntPtr
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void FromIntPtrDelegate(IntPtr ptr);
        public string Value { get; protected set; }
        public void FromIntPtr(IntPtr ptr)
        {
            Value = Marshal.PtrToStringAnsi(ptr);
        }
    }
