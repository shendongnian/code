    public static String GetUserPath()
    {
        var hUserToken = IntPtr.Zero;
        IntPtr pidlist = IntPtr.Zero;
        StringBuilder sb = new StringBuilder(MAX_PATH);
        GetSessionUserToken(ref hUserToken);
        SHGetFolderLocation(IntPtr.Zero, CSIDL_LOCAL_APPDATA, hUserToken, 0, out pidlist);
        SHGetPathFromIDListW(pidlist, sb);
        return sb.ToString();
    }
    private static bool GetSessionUserToken(ref IntPtr phUserToken)
    {
        var bResult = false;
        var hImpersonationToken = IntPtr.Zero;
        var activeSessionId = INVALID_SESSION_ID;
        var pSessionInfo = IntPtr.Zero;
        var sessionCount = 0;
        // Get a handle to the user access token for the current active session.
        if (WTSEnumerateSessions(WTS_CURRENT_SERVER_HANDLE, 0, 1, ref pSessionInfo, ref sessionCount) != 0)
        {
            var arrayElementSize = Marshal.SizeOf(typeof(WTS_SESSION_INFO));
            var current = pSessionInfo;
            for (var i = 0; i < sessionCount; i++)
            {
                var si = (WTS_SESSION_INFO)Marshal.PtrToStructure((IntPtr)current, typeof(WTS_SESSION_INFO));
                //current = new IntPtr(current.ToInt64() + arrayElementSize);
                current = (IntPtr)((long)current + arrayElementSize); // should be same as above line
                if (si.State == WTS_CONNECTSTATE_CLASS.WTSActive)
                {
                    activeSessionId = si.SessionID;
                }
            }
        }
        // If enumerating did not work, fall back to the old method
        if (activeSessionId == INVALID_SESSION_ID)
        {
            activeSessionId = WTSGetActiveConsoleSessionId();
        }
        SECURITY_ATTRIBUTES sa = new SECURITY_ATTRIBUTES();
        sa.nLength = Marshal.SizeOf(sa);
        if (WTSQueryUserToken(activeSessionId, ref hImpersonationToken) != 0)
        {
            // Convert the impersonation token to a primary token
            bResult = DuplicateTokenEx(
                hImpersonationToken, 
                0, 
                ref sa,//IntPtr.Zero,
                (int)SECURITY_IMPERSONATION_LEVEL.SecurityDelegation,
                (int)TOKEN_TYPE.TokenPrimary,
                ref phUserToken);
            CloseHandle(hImpersonationToken);
        }
        return bResult;
    }
    private const int CSIDL_LOCAL_APPDATA = 0x001c;
    private const int MAX_PATH = 260;
