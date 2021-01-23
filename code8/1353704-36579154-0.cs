       public override void Delete()
        {
    #if FEATURE_CORECLR
            FileSecurityState state = new FileSecurityState(FileSecurityStateAccess.Write, DisplayPath, FullPath);
            state.EnsureState();
    #else
            // For security check, path should be resolved to an absolute path.
            new FileIOPermission(FileIOPermissionAccess.Write, new String[] { FullPath }, false, false).Demand();
    #endif
 
            bool r = Win32Native.DeleteFile(FullPath);
            if (!r) {
                int hr = Marshal.GetLastWin32Error();
                if (hr==Win32Native.ERROR_FILE_NOT_FOUND)
                    return;
                else
                    __Error.WinIOError(hr, DisplayPath);
            }
        }
