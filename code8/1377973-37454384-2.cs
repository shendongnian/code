    public const int WM_DEVICECHANGE = 0x219;
    public const int DBT_DEVTYP_VOLUME = 0x00000002;
    public const int DBT_DEVICEARRIVAL = 0x8000;
    public const int DBT_DEVTYP_DEVICEINTERFACE = 0x00000005;
    private IntPtr notificationHandle;
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr RegisterDeviceNotification(IntPtr recipient, IntPtr notificationFilter, int flags);
    [StructLayout(LayoutKind.Sequential)]
    internal class DEV_BROADCAST_HDR
    {
        public int dbch_size;
        public int dbch_devicetype;
        public int dbch_reserved;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DEV_BROADCAST_DEVICEINTERFACE
    {
        public int dbcc_size;
        public int dbcc_devicetype;
        public int dbcc_reserved;
        public Guid dbcc_classguid;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public char[] dbcc_name;
    }
    public void WndProc(ref Message m)
    {
        if (m.Msg == WM_DEVICECHANGE) //Device state has changed
        {
           switch (m.WParam.ToInt32())
           {
               case DBT_DEVICEARRIVAL: //New device arrives
               DEV_BROADCAST_HDR hdr;
               hdr = (DEV_BROADCAST_HDR)Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_HDR));
                            if (hdr.dbch_devicetype == DBT_DEVTYP_DEVICEINTERFACE) //If it is a USB Mass Storage or Hard Drive
                            {
                                //Save Device name
                                DEV_BROADCAST_DEVICEINTERFACE deviceInterface = (DEV_BROADCAST_DEVICEINTERFACE)Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_DEVICEINTERFACE));
                                deviceName = new string(deviceInterface.dbcc_name);
                                deviceNameFiltered = deviceName.Substring(0, deviceName.IndexOf('{'));
                                vid = GetVid(deviceName);
                                pid = GetPid(deviceName);
                            }
                            if (hdr.dbch_devicetype == DBT_DEVTYP_VOLUME)
                            { 
                                DEV_BROADCAST_VOLUME volume;
                                volume = (DEV_BROADCAST_VOLUME)Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_VOLUME));
                                //Translate mask to device letter
                                driveLetter = DriveMaskToLetter(volume.dbcv_unitmask);
           }
        }
    }
