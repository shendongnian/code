    [StructLayout(LayoutKind.Sequential)]
    public struct DelphiShortString
    {
        private byte length;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=255)]
        private byte[] payload;
        public string Value 
        {
            get 
            { 
                return Encoding.Default.GetString(payload, 0, length); 
            }
            set 
            {
                length = (byte)Math.Min(value.Length, 255);
                payload = Encoding.Default.GetBytes(value.Substring(0, length));
            }
        }
    }
