    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsWindowsVersionOrGreater(6, 3, 0)); // Plug in appropriate values.
        }
        [StructLayout(LayoutKind.Sequential)]
        struct OsVersionInfoEx
        {
            public uint OSVersionInfoSize;
            public uint MajorVersion;
            public uint MinorVersion;
            public uint BuildNumber;
            public uint PlatformId;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string CSDVersion;
            public ushort ServicePackMajor;
            public ushort ServicePackMinor;
            public ushort SuiteMask;
            public byte ProductType;
            public byte Reserved;
        }
        [DllImport("kernel32.dll")]
        static extern ulong VerSetConditionMask(ulong dwlConditionMask,
           uint dwTypeBitMask, byte dwConditionMask);
        [DllImport("kernel32.dll")]
        static extern bool VerifyVersionInfo(
            [In] ref OsVersionInfoEx lpVersionInfo,
            uint dwTypeMask, ulong dwlConditionMask);
        static bool IsWindowsVersionOrGreater(
            uint majorVersion, uint minorVersion, ushort servicePackMajor)
        {
            OsVersionInfoEx osvi = new OsVersionInfoEx();
            osvi.OSVersionInfoSize = (uint)Marshal.SizeOf(osvi);
            osvi.MajorVersion = majorVersion;
            osvi.MinorVersion = minorVersion;
            osvi.ServicePackMajor = servicePackMajor;
            // These constants initialized with corresponding definitions in
            // winnt.h (part of Windows SDK)
            const uint VER_MINORVERSION = 0x0000001;
            const uint VER_MAJORVERSION = 0x0000002;
            const uint VER_SERVICEPACKMAJOR = 0x0000020;
            const byte VER_GREATER_EQUAL = 3;
            ulong versionOrGreaterMask = VerSetConditionMask(
                VerSetConditionMask(
                    VerSetConditionMask(
                        0, VER_MAJORVERSION, VER_GREATER_EQUAL),
                    VER_MINORVERSION, VER_GREATER_EQUAL),
                VER_SERVICEPACKMAJOR, VER_GREATER_EQUAL);
            uint versionOrGreaterTypeMask = VER_MAJORVERSION |
                VER_MINORVERSION | VER_SERVICEPACKMAJOR;
            return VerifyVersionInfo(ref osvi, versionOrGreaterTypeMask,
                versionOrGreaterMask);
        }
    }
