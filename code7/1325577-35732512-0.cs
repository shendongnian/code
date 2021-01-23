    [Guid("12345678-1234-1234-1234-123456789abc"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    interface ISampleInterface
    {
        [DispId(17)]  // set the DISPID of the method
        [return: MarshalAs(UnmanagedType.Interface)]  // set the marshaling on the return type 
        object DoWork();
    }
