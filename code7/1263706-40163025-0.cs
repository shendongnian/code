    using System.Runtime.InteropServices;
    
    namespace System
    {
    
    
        // [ComVisible(true)]
        // [Serializable]
        public enum PlatformID
        {
            Win32S = 0,
            Win32Windows = 1,
            Win32NT = 2,
            WinCE = 3,
            Unix = 4,
            // Since NET 3.5 SP1 or silverlight
            Xbox = 5,
            MacOSX = 6,
        }
    
    
        public class OperatingSystem
        {
            private Architecture m_arch;
            private bool m_isARM;
            private bool m_isX86;
            private bool m_isLinux;
            private bool m_isOSX;
            private bool m_isWindows;
            private PlatformID m_platform;
    
            public OperatingSystem()
            {
                m_arch = RuntimeInformation.ProcessArchitecture;
                m_isARM = (m_arch == Architecture.Arm || m_arch == Architecture.Arm64);
                m_isX86 = (m_arch == Architecture.X86 || m_arch == Architecture.X64);
    
                m_isLinux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
                m_isOSX = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
                m_isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
    
                if (m_isLinux || m_isOSX)
                    m_platform = PlatformID.Unix;
                else if (m_isWindows)
                {
                    m_platform = PlatformID.Win32NT;
                }
                else
                    throw new System.PlatformNotSupportedException("Operating system not supported.");
            }
    
            public PlatformID Platform
            {
                get
                {
                    return m_platform;
                }
            }
        }
    
    
    
        public class OldEnvironment
        {
    
            private static OperatingSystem m_OS;
    
            static OldEnvironment()
            {
                m_OS = new OperatingSystem();
            }
            
            public static OperatingSystem OSVersion
            {
                get
                {
                    return m_OS;
                }
            }
    
        }
    
    
    }
