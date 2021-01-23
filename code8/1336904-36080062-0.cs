    [StructLayout(LayoutKind.Sequential)]
    public struct MSG_STRUCT 
    {
        int dataSize;
        IntPtr data;
        public byte[] GetData() 
        {
            var bytes = new byte[dataSize];
            Marshal.Copy(data, bytes, 0, dataSize);
            return bytes;
        }
    }
    [DllImport("NativeLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint ReadMsg(uint msgId, ref MSG_STRUCT readMsg);
