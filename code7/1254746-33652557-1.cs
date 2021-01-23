    private static Size GetConsoleFontSize()
    {
        // getting the console out buffer handle
        IntPtr outHandle = CreateFile("CONOUT$", GENERIC_READ | GENERIC_WRITE, 
            FILE_SHARE_READ | FILE_SHARE_WRITE,
            null,
            OPEN_EXISTING,
            0,
            IntPtr.Zero);
        int errorCode = Marshal.GetLastWin32Error();
        if (outHandle.ToInt32() == INVALID_HANDLE_VALUE)
        {
            throw new IOException("Unable to open CONOUT$", errorCode);
        }
        ConsoleFontInfo cfi = new ConsoleFontInfo();
        if (!GetCurrentConsoleFont(outHandle, false, cfi))
        {
            throw new InvalidOperationException("Unable to get font information.");
        }
        return new Size(cfi.dwFontSize.X, cfi.dwFontSize.Y);            
    }
