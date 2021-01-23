    try
    {
        using (var stream = File.Open("my file name", FileMode.Open, FileAccess.ReadWrite, FileShare.None))
        {
            // Do with it what you want.
        }
    }
    catch (IOException ex)
    {
        if (IsFileLocked(ex)
            // try later.
        else
            // report error.
    }
    ...
    const int ERROR_SHARING_VIOLATION = 32;
    const int ERROR_LOCK_VIOLATION = 33;
    private static bool IsFileLocked(Exception exception)
    {
        int errorCode = Marshal.GetHRForException(exception) & ((1 << 16) - 1);
        return errorCode == ERROR_SHARING_VIOLATION || errorCode == ERROR_LOCK_VIOLATION;
    }
