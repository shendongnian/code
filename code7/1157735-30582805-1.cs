    // raw input, as a string
    string s = "\u0001\u0001\u0004\0\u0001\0\0\0";
    // convert string into byte array
    byte[] bytes = new byte[s.Length * sizeof(char)];
    Buffer.BlockCopy(s.ToCharArray(), 0, bytes, 0, bytes.Length);
    // interpret byte array as `Data` object
    GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
    Data data = (Data)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(Data));
    handle.Free();
    // access the data!
    Console.WriteLine(data.serviceVersion); // 1
    Console.WriteLine(data.statusCode); // 1
    Console.WriteLine(data.requestId); // 4
