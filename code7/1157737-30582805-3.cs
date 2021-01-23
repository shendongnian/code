    // raw input, as a string
    string s = "\u0001\u0001\u0004\0\u0001\0\0\0";
    // convert string into byte array
    byte[] bytes = Encoding.UTF8.GetBytes(s);
    // interpret byte array as `Data` object
    GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
    Data data = (Data)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(Data));
    handle.Free();
    // access the data!
    Console.WriteLine(data.serviceVersion); // 257
    Console.WriteLine(data.statusCode); // 4
    Console.WriteLine(data.requestId); // 1
