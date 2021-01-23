    [ComImport][Guid("0000000b-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IStorage
    {
        void Dummy1();
        [return: MarshalAs(UnmanagedType.Interface)]
        IStream OpenStream([In, MarshalAs(UnmanagedType.BStr)] string pwcsName, IntPtr reserved1, [In, MarshalAs(UnmanagedType.U4)] int grfMode, [In, MarshalAs(UnmanagedType.U4)] int reserved2);
        void Dummy3();
        void Dummy4();
        void Dummy5();
        void Dummy6();
        void Dummy7();
        void Dummy8();
        void EnumElements(
            /* [in] */ uint reserved1,
            /* [size_is][unique][in] */ IntPtr reserved2,
            /* [in] */ uint reserved3,
            /* [out] */ out IEnumSTATSTG ppenum);
    }
