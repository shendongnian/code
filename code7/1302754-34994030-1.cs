    public static readonly Guid Desktop = new Guid( "B4BFCC3A-DB2C-424C-B029-7FE99A87C641" );
    
    public static readonly Guid PublicDesktop = new Guid( "C4AA340D-F20F-4863-AFEF-F87EF2E6BA25" );
    IntPtr token = AllWTSQueryUserTokens().First(); // <-- Your implementation
    IntPtr pPath;
    if ( SHGetKnownFolderPath(PublicDesktop, 0, token, out pPath ) == 0 )
    {
        string s = System.Runtime.InteropServices.Marshal.PtrToStringUni( pPath );
        System.Runtime.InteropServices.Marshal.FreeCoTaskMem( pPath );
        // s now contains the path for the all-users "Public Desktop" folder
    }
    // Release memory (token)!
