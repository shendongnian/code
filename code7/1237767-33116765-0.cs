    [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
    public extern static IntPtr SHA256(byte[] data, long len, byte[] result);
-
    byte[] data = Encoding.ASCII.GetBytes("some_data_to_hash");
    
    IntPtr r = NOpenSSL.Wrapper.SHA256(data, data.Length, null);
    byte[] output = new byte[32];
    Marshal.Copy(r, output, 0, output.Length);
    
    // output contains now the 32 bytes of the hashed data
