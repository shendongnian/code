    try
    {
        //Write stuff to disk
    }
    catch(IOException ex)
    {
        if(IsDiskFull(ex))
        {
            //Disk is full
        }
    }
    public static bool IsDiskFull(Exception ex)
    {
        const int ERROR_HANDLE_DISK_FULL = 0x27;
        const int ERROR_DISK_FULL = 0x70;
    
        int win32ErrorCode = Marshal.GetHRForException(ex) & 0xFFFF;
        return win32ErrorCode == ERROR_HANDLE_DISK_FULL || win32ErrorCode == ERROR_DISK_FULL;
    }
