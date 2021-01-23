    [StructLayout(LayoutKind.Sequential)]
    struct FieldIndex {
       public byte Typecode;
       [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
       private byte[] Utf8string;
       public string GetString() {
          return Encoding.UTF8.GetString(Utf8string, 0, 15);
       }
    }
