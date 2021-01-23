    public unsafe static class DataPackg
    {
       [StructLayout(LayoutKind.Sequential)]
       public struct TestC
       {
          public uint Id;
          [MarshalAs(UnmanagedType.LPStr)]
          public String StrVal;
       }
    }
