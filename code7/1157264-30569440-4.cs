    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DelphiShortString
    {
        private byte length;
        private fixed byte payload[255];
        public string Value 
        {
            get 
            {
                {
                    byte[] bytes = new byte[length];
                    fixed (byte* ptr = payload)
                    {
                        Marshal.Copy((IntPtr)ptr, bytes, 0, length);
                    }
                    return Encoding.Default.GetString(bytes, 0, length); 
                }
            }
            set 
            {
                length = (byte)Math.Min(value.Length, 255);
                byte[] bytes = Encoding.Default.GetBytes(value.Substring(0, length));
                fixed (byte* ptr = payload)
                {
                    Marshal.Copy(bytes, 0, (IntPtr)ptr, length);
                }
            }
        }
    }
