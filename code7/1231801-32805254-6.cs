    /// <summary>
    /// Microsoft IMAPIv2 Disc Master
    /// </summary>
    [ComImport]
    [Guid("27354130-7F64-5B0F-8F00-5D77AFBE261E")]
    [CoClass(typeof(MsftDiscMaster2Class))]
    public interface MsftDiscMaster2 : IDiscMaster2 //, DiscMaster2_Event
    {
    }
    [ComImport, ComSourceInterfaces("DDiscMaster2Events\0")]
    [TypeLibType(TypeLibTypeFlags.FCanCreate)]
    [Guid("2735412E-7F64-5B0F-8F00-5D77AFBE261E")]
    [ClassInterface(ClassInterfaceType.None)]
    public class MsftDiscMaster2Class
    {
    }
    [ComImport]
    [CoClass(typeof(MsftDiscRecorder2Class))]
    [Guid("27354133-7F64-5B0F-8F00-5D77AFBE261E")]
    public interface MsftDiscRecorder2 : IDiscRecorder2
    {
    }
    [ComImport]
    [Guid("2735412D-7F64-5B0F-8F00-5D77AFBE261E")]
    [TypeLibType(TypeLibTypeFlags.FCanCreate)]
    [ClassInterface(ClassInterfaceType.None)]
    public class MsftDiscRecorder2Class
    {
    }
    /// <summary>
    /// IDiscMaster2 is used to get an enumerator for the set of CD/DVD (optical) devices on the system
    /// </summary>
    [ComImport]
    [Guid("27354130-7F64-5B0F-8F00-5D77AFBE261E")]
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    public interface IDiscMaster2
    {
        // Enumerates the list of CD/DVD devices on the system (VT_BSTR)
        [DispId(-4), TypeLibFunc((short)0x41)]
        IEnumerator GetEnumerator();
        // Gets a single recorder's ID (ZERO BASED INDEX)
        [DispId(0)]
        string this[int index] { get; }
        // The current number of recorders in the system.
        [DispId(1)]
        int Count { get; }
        // Whether IMAPI is running in an environment with optical devices and permission to access them.
        [DispId(2)]
        bool IsSupportedEnvironment { get; }
    }
    /// <summary>
    ///  Represents a single CD/DVD type device, and enables many common operations via a simplified API.
    /// </summary>
    [ComImport]
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    [Guid("27354133-7F64-5B0F-8F00-5D77AFBE261E")]
    public interface IDiscRecorder2
    {
        // Ejects the media (if any) and opens the tray
        [DispId(0x100)]
        void EjectMedia();
        // Close the media tray and load any media in the tray.
        [DispId(0x101)]
        void CloseTray();
        // Acquires exclusive access to device.  May be called multiple times.
        [DispId(0x102)]
        void AcquireExclusiveAccess(bool force, string clientName);
        // Releases exclusive access to device.  Call once per AcquireExclusiveAccess().
        [DispId(0x103)]
        void ReleaseExclusiveAccess();
        // Disables Media Change Notification (MCN).
        [DispId(260)]
        void DisableMcn();
        // Re-enables Media Change Notification after a call to DisableMcn()
        [DispId(0x105)]
        void EnableMcn();
        // Initialize the recorder, opening a handle to the specified recorder.
        [DispId(0x106)]
        void InitializeDiscRecorder(string recorderUniqueId);
        // The unique ID used to initialize the recorder.
        [DispId(0)]
        string ActiveDiscRecorder { get; }
        // The vendor ID in the device's INQUIRY data.
        [DispId(0x201)]
        string VendorId { get; }
        // The Product ID in the device's INQUIRY data.
        [DispId(0x202)]
        string ProductId { get; }
        // The Product Revision in the device's INQUIRY data.
        [DispId(0x203)]
        string ProductRevision { get; }
        // Get the unique volume name (this is not a drive letter).
        [DispId(0x204)]
        string VolumeName { get; }
        // Drive letters and NTFS mount points to access the recorder.
        [DispId(0x205)]
        object[] VolumePathNames {[DispId(0x205)] get; }
        // One of the volume names associated with the recorder.
        [DispId(0x206)]
        bool DeviceCanLoadMedia {[DispId(0x206)] get; }
        // Gets the legacy 'device number' associated with the recorder.  This number is not guaranteed to be static.
        [DispId(0x207)]
        int LegacyDeviceNumber {[DispId(0x207)] get; }
        // Gets a list of all feature pages supported by the device
        [DispId(520)]
        object[] SupportedFeaturePages {[DispId(520)] get; }
        // Gets a list of all feature pages with 'current' bit set to true
        [DispId(0x209)]
        object[] CurrentFeaturePages {[DispId(0x209)] get; }
        // Gets a list of all profiles supported by the device
        [DispId(0x20a)]
        object[] SupportedProfiles {[DispId(0x20a)] get; }
        // Gets a list of all profiles with 'currentP' bit set to true
        [DispId(0x20b)]
        object[] CurrentProfiles {[DispId(0x20b)] get; }
        // Gets a list of all MODE PAGES supported by the device
        [DispId(0x20c)]
        object[] SupportedModePages {[DispId(0x20c)] get; }
        // Queries the device to determine who, if anyone, has acquired exclusive access
        [DispId(0x20d)]
        string ExclusiveAccessOwner {[DispId(0x20d)] get; }
    }
    public enum IMAPI_FEATURE_PAGE_TYPE
    {
        IMAPI_FEATURE_PAGE_TYPE_PROFILE_LIST = 0,
        IMAPI_FEATURE_PAGE_TYPE_CORE = 1,
        IMAPI_FEATURE_PAGE_TYPE_MORPHING = 2,
        IMAPI_FEATURE_PAGE_TYPE_REMOVABLE_MEDIUM = 3,
        IMAPI_FEATURE_PAGE_TYPE_WRITE_PROTECT = 4,
        IMAPI_FEATURE_PAGE_TYPE_RANDOMLY_READABLE = 0x10,
        IMAPI_FEATURE_PAGE_TYPE_CD_MULTIREAD = 0x1d,
        IMAPI_FEATURE_PAGE_TYPE_CD_READ = 0x1e,
        IMAPI_FEATURE_PAGE_TYPE_DVD_READ = 0x1f,
        IMAPI_FEATURE_PAGE_TYPE_RANDOMLY_WRITABLE = 0x20,
        IMAPI_FEATURE_PAGE_TYPE_INCREMENTAL_STREAMING_WRITABLE = 0x21,
        IMAPI_FEATURE_PAGE_TYPE_SECTOR_ERASABLE = 0x22,
        IMAPI_FEATURE_PAGE_TYPE_FORMATTABLE = 0x23,
        IMAPI_FEATURE_PAGE_TYPE_HARDWARE_DEFECT_MANAGEMENT = 0x24,
        IMAPI_FEATURE_PAGE_TYPE_WRITE_ONCE = 0x25,
        IMAPI_FEATURE_PAGE_TYPE_RESTRICTED_OVERWRITE = 0x26,
        IMAPI_FEATURE_PAGE_TYPE_CDRW_CAV_WRITE = 0x27,
        IMAPI_FEATURE_PAGE_TYPE_MRW = 0x28,
        IMAPI_FEATURE_PAGE_TYPE_ENHANCED_DEFECT_REPORTING = 0x29,
        IMAPI_FEATURE_PAGE_TYPE_DVD_PLUS_RW = 0x2a,
        IMAPI_FEATURE_PAGE_TYPE_DVD_PLUS_R = 0x2b,
        IMAPI_FEATURE_PAGE_TYPE_RIGID_RESTRICTED_OVERWRITE = 0x2c,
        IMAPI_FEATURE_PAGE_TYPE_CD_TRACK_AT_ONCE = 0x2d,
        IMAPI_FEATURE_PAGE_TYPE_CD_MASTERING = 0x2e,
        IMAPI_FEATURE_PAGE_TYPE_DVD_DASH_WRITE = 0x2f,
        IMAPI_FEATURE_PAGE_TYPE_DOUBLE_DENSITY_CD_READ = 0x30,
        IMAPI_FEATURE_PAGE_TYPE_DOUBLE_DENSITY_CD_R_WRITE = 0x31,
        IMAPI_FEATURE_PAGE_TYPE_DOUBLE_DENSITY_CD_RW_WRITE = 0x32,
        IMAPI_FEATURE_PAGE_TYPE_LAYER_JUMP_RECORDING = 0x33,
        IMAPI_FEATURE_PAGE_TYPE_CD_RW_MEDIA_WRITE_SUPPORT = 0x37,
        IMAPI_FEATURE_PAGE_TYPE_BD_PSEUDO_OVERWRITE = 0x38,
        IMAPI_FEATURE_PAGE_TYPE_DVD_PLUS_R_DUAL_LAYER = 0x3b,
        IMAPI_FEATURE_PAGE_TYPE_BD_READ = 0x40,
        IMAPI_FEATURE_PAGE_TYPE_BD_WRITE = 0x41,
        IMAPI_FEATURE_PAGE_TYPE_HD_DVD_READ = 0x50,
        IMAPI_FEATURE_PAGE_TYPE_HD_DVD_WRITE = 0x51,
        IMAPI_FEATURE_PAGE_TYPE_POWER_MANAGEMENT = 0x100,
        IMAPI_FEATURE_PAGE_TYPE_SMART = 0x101,
        IMAPI_FEATURE_PAGE_TYPE_EMBEDDED_CHANGER = 0x102,
        IMAPI_FEATURE_PAGE_TYPE_CD_ANALOG_PLAY = 0x103,
        IMAPI_FEATURE_PAGE_TYPE_MICROCODE_UPDATE = 0x104,
        IMAPI_FEATURE_PAGE_TYPE_TIMEOUT = 0x105,
        IMAPI_FEATURE_PAGE_TYPE_DVD_CSS = 0x106,
        IMAPI_FEATURE_PAGE_TYPE_REAL_TIME_STREAMING = 0x107,
        IMAPI_FEATURE_PAGE_TYPE_LOGICAL_UNIT_SERIAL_NUMBER = 0x108,
        IMAPI_FEATURE_PAGE_TYPE_MEDIA_SERIAL_NUMBER = 0x109,
        IMAPI_FEATURE_PAGE_TYPE_DISC_CONTROL_BLOCKS = 0x10a,
        IMAPI_FEATURE_PAGE_TYPE_DVD_CPRM = 0x10b,
        IMAPI_FEATURE_PAGE_TYPE_FIRMWARE_INFORMATION = 0x10c,
        IMAPI_FEATURE_PAGE_TYPE_AACS = 0x10d,
        IMAPI_FEATURE_PAGE_TYPE_VCPS = 0x110
    }
