    var bytes = new byte[] { 1, 0, 0, 0, 2, 0, 0, 0, 3, 0, 4, 0, 0, 0, 0, 0, 0, 0 };
    GCHandle gcHandle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
    var data = (Data)Marshal.PtrToStructure(gcHandle.AddrOfPinnedObject(), typeof(Data));
    gcHandle.Free();
            
    // Now data should contain the correct values.
    Console.WriteLine(data._int1);    // Prints 1
    Console.WriteLine(data._int2);    // Prints 2
    Console.WriteLine(data._short1);  // Prints 3
    Console.WriteLine(data._long1);   // Prints 4
