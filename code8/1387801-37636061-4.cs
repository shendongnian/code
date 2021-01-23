    public enum CREATE_VIRTUAL_DISK_VERSION
    {
        CREATE_VIRTUAL_DISK_VERSION_UNSPECIFIED = 0,
        CREATE_VIRTUAL_DISK_VERSION_1 = 1,
        CREATE_VIRTUAL_DISK_VERSION_2 = 2
    };
    public enum OPEN_VIRTUAL_DISK_FLAG
    {
        OPEN_VIRTUAL_DISK_FLAG_NONE = 0x00000000,
        OPEN_VIRTUAL_DISK_FLAG_NO_PARENTS = 0x00000001,
        OPEN_VIRTUAL_DISK_FLAG_BLANK_FILE = 0x00000002,
        OPEN_VIRTUAL_DISK_FLAG_BOOT_DRIVE = 0x00000004,
        OPEN_VIRTUAL_DISK_FLAG_CACHED_IO = 0x00000008,
        OPEN_VIRTUAL_DISK_FLAG_CUSTOM_DIFF_CHAIN = 0x00000010
    };
    [StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Unicode)]
    public struct VIRTUAL_STORAGE_TYPE
    {
        uint DeviceId;
        Guid VendorId;
    };
    [StructLayout(LayoutKind.Explicit, Pack = 8, CharSet = CharSet.Unicode)]
    public struct CreateVirtualDiskParameters
    {
        [FieldOffset(0)]
        public CREATE_VIRTUAL_DISK_VERSION Version;
        [FieldOffset(8))]
        public CreateVirtualDiskParametersVersion1 Version1;
        [FieldOffset(8))]
        public CreateVirtualDiskParametersVersion2 Version2;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Unicode)]
    public struct CreateVirtualDiskParametersVersion1
    {
        public Guid UniqueId;
        public ulong MaximumSize;
        public uint BlockSizeInBytes;
        public uint SectorSizeInBytes;
        //public IntPtr ParentPath;   // PCWSTR in C++ which is a pointer to a Unicode string
        //public IntPtr SourcePath;   //string
        [MarshalAs(UnmanagedType.LPWStr)] public string ParentPath;
        [MarshalAs(UnmanagedType.LPWStr)] public string SourcePath;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Unicode)]
    public struct CreateVirtualDiskParametersVersion2
    {
        public Guid UniqueId;
        public ulong MaximumSize;
        public uint BlockSizeInBytes;
        public uint SectorSizeInBytes;
        public uint PhysicalSectorSizeInBytes;
        //public IntPtr ParentPath;   //string
        //public IntPtr SourcePath;   //string
        [MarshalAs(UnmanagedType.LPWStr)] public string ParentPath;
        [MarshalAs(UnmanagedType.LPWStr)] public string SourcePath;
        public OPEN_VIRTUAL_DISK_FLAG OpenFlags;
        public VIRTUAL_STORAGE_TYPE ParentVirtualStorageType;
        public VIRTUAL_STORAGE_TYPE SourceVirtualStorageType;
        public Guid ResiliencyGuid;
    }
