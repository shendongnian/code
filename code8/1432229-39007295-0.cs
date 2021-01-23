    public static byte[] Foo<T>(this T input) where T : struct
    {
      int size = Marshal.SizeOf(typeof(T));
      var result = new byte[size];
      var gcHandle = GCHandle.Alloc(input, GCHandleType.Pinned);
      Marshal.Copy(gcHandle.AddrOfPinnedObject(), result, 0, size);
      gcHandle.Free();
      return result;
    }
