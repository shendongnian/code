    public delegate Byte SomeDelegate([MarshalAs(UnmanagedType.I4)] int value);
    [DllImport("mylibraryname.dll")]
    public static extern Byte someMethod([MarshalAs(UnmanagedType.FunctionPtr)]
                                           ref SomeDelegate pDelegate);
    Byte MyMethod([MarshalAs(UnmanagedType.I4)] int value)
    {
        return (byte) (value & 0xFF);
    }
