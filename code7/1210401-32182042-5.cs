    static byte[] GetBytes<T>(T input)
      where T : struct
    {
	    int size = Marshal.SizeOf(typeof(T));
	    byte[] result = new byte[size];
	    GCHandle gc = GCHandle.Alloc(input, GCHandleType.Pinned);
	    try
	    {
	    	Marshal.Copy(gc.AddrOfPinnedObject(), result, 0, size);
	    }
	    finally
	    {
		    gc.Free();
	    }
	    return result;
    }
