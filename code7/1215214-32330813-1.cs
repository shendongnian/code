    // Summary:
    //     Identifies the operating system, or platform, supported by an assembly.
    [Serializable]
    [ComVisible(true)]
    public enum PlatformID
    {
        // Summary:
        //     The operating system is Win32s. Win32s is a layer that runs on 16-bit versions
        //     of Windows to provide access to 32-bit applications.
        Win32S = 0,
        //
        // Summary:
        //     The operating system is Windows 95 or Windows 98.
        Win32Windows = 1,
        //
        // Summary:
        //     The operating system is Windows NT or later.
        Win32NT = 2,
        //
        // Summary:
        //     The operating system is Windows CE.
        WinCE = 3,
        //
        // Summary:
        //     The operating system is Unix.
        Unix = 4,
        //
        // Summary:
        //     The development platform is Xbox 360.
        Xbox = 5,
        //
        // Summary:
        //     The operating system is Macintosh.
        MacOSX = 6,
    }
