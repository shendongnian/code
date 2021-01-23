    static IEnumerable<DriveInfo> GetUsbDevices()
    {
        IEnumerable<string> usbDrivesLetters = new ManagementObjectSearcher("select * from Win32_DiskDrive WHERE InterfaceType='USB'").Get().Cast<ManagementObject>()
            .SelectMany(drive => drive.GetRelated("Win32_DiskPartition").Cast<ManagementObject>())
            .SelectMany(o => o.GetRelated("Win32_LogicalDisk").Cast<ManagementObject>())
            .Select(i => Convert.ToString(i["Name"]) + "\\");
        return DriveInfo.GetDrives().Where(drive => drive.DriveType == DriveType.Removable && usbDrivesLetters.Contains(drive.RootDirectory.Name));
    }
