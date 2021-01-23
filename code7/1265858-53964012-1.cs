    public bool Initialize()
    {
        Dispose();
        if (DeviceInformation == null)
        {
            throw new WindowsHidException($"{nameof(DeviceInformation)} must be specified before {nameof(Initialize)} can be called.");
        }
        var pointerToPreParsedData = new IntPtr();
        _HidCollectionCapabilities = new HidCollectionCapabilities();
        var pointerToBuffer = Marshal.AllocHGlobal(126);
        _ReadSafeFileHandle = APICalls.CreateFile(DeviceInformation.DeviceId, APICalls.GenericRead | APICalls.GenericWrite, APICalls.FileShareRead | APICalls.FileShareWrite, IntPtr.Zero, APICalls.OpenExisting, 0, IntPtr.Zero);
        _WriteSafeFileHandle = APICalls.CreateFile(DeviceInformation.DeviceId, APICalls.GenericRead | APICalls.GenericWrite, APICalls.FileShareRead | APICalls.FileShareWrite, IntPtr.Zero, APICalls.OpenExisting, 0, IntPtr.Zero);
        if (!HidAPICalls.HidD_GetPreparsedData(_ReadSafeFileHandle, ref pointerToPreParsedData))
        {
            throw new Exception("Could not get pre parsed data");
        }
        var getCapsResult = HidAPICalls.HidP_GetCaps(pointerToPreParsedData, ref _HidCollectionCapabilities);
        //TODO: Deal with issues here
        Marshal.FreeHGlobal(pointerToBuffer);
        var preparsedDataResult = HidAPICalls.HidD_FreePreparsedData(ref pointerToPreParsedData);
        //TODO: Deal with issues here
        if (_ReadSafeFileHandle.IsInvalid)
        {
            return false;
        }
        _ReadFileStream = new FileStream(_ReadSafeFileHandle, FileAccess.ReadWrite, _HidCollectionCapabilities.OutputReportByteLength, false);
        _WriteFileStream = new FileStream(_WriteSafeFileHandle, FileAccess.ReadWrite, _HidCollectionCapabilities.InputReportByteLength, false);
        IsInitialized = true;
        RaiseConnected();
        return true;
    }
