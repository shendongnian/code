    bool result3 = Win32.SetupDiGetDeviceInterfaceDetail(hDevInfo, ifData, IntPtr.Zero, 0, 
        out needed, null);
    if(!result3)
    {
        int error = Marshal.GetLastWin32Error();
    }
    // expect that result3 is false and that error is ERROR_INSUFFICIENT_BUFFER = 122, 
    // and needed is the required size
    IntPtr DeviceInterfaceDetailData = Marshal.AllocHGlobal((int)needed);
    try
    {
        uint size = needed;
        Marshal.WriteInt32(DeviceInterfaceDetailData, (int)size);
        bool result4 = Win32.SetupDiGetDeviceInterfaceDetail(hDevInfo, ifData, 
            DeviceInterfaceDetailData, size, out needed, null);
        if(!result4)
        {
            int error = Marshal.GetLastWin32Error();
        }
        // do whatever you need with DeviceInterfaceDetailData
    }
    finally
    {
        Marshal.FreeHGlobal(DeviceInterfaceDetailData);
    }
