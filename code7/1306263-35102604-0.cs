    public unsafe DbgHelp.MINIDUMP_HANDLE_OBJECT_INFORMATION ReadInfo(uint rva, IntPtr streamPtr)
    {
        DbgHelp.MINIDUMP_HANDLE_OBJECT_INFORMATION result = new DbgHelp.MINIDUMP_HANDLE_OBJECT_INFORMATION();
    
        try
        {
            byte* baseOfView = null;
            _safeMemoryMappedViewHandle.AcquirePointer(ref baseOfView);
            ulong offset = (ulong)streamPtr - (ulong)baseOfView;
            result = _safeMemoryMappedViewHandle.Read<DbgHelp.MINIDUMP_HANDLE_OBJECT_INFORMATION>(offset);
        }
        finally
        {
            _safeMemoryMappedViewHandle.ReleasePointer();
        }
    
        return result;
    }
