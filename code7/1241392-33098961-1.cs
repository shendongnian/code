    public static byte[] ToLEByteArray<T>(T value) where T: struct {
      int size = Marshal.SizeOf(typeof(T));
      byte[] bytes = new byte[size];
      IntPtr p = Marshal.AllocHGlobal(size);
      try {
        Marshal.StructureToPtr(value, p, true);
        Marshal.Copy(p, bytes, 0, size);
      }
      finally {
        Marshal.FreeHGlobal(p);
      }
      // If it was big endian, reverse it
      if (!BitConverter.IsLittleEndian)
        Array.Reverse(bytes);
      return bytes;
    }
....
      Byte b = 123;
      ushort s = 123;
      ulong l = 123;
    
      Byte[] result_byte = ToLEByteArray(b);
      Byte[] result_ushort = ToLEByteArray(s);
      Byte[] result_ulong = ToLEByteArray(l);
