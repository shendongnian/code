    public static string AppContainerNameToSid(string appContainerName)
    {
        var sid = IntPtr.Zero;
        try
        {
            if (DeriveAppContainerSidFromAppContainerName(appContainerName, out sid) == 0)
                return new SecurityIdentifier(sid).Value;
            else
                return null;
        }
        finally
        {
            if (sid != IntPtr.Zero)
                FreeSid(sid);
        }
    }
    [DllImport("userenv.dll", SetLastError = false, CharSet = CharSet.Unicode)]
    private static extern int DeriveAppContainerSidFromAppContainerName(string appContainerName, out IntPtr sid);
    [DllImport("advapi32.dll", SetLastError = false)]
    private static extern IntPtr FreeSid(IntPtr sid);
