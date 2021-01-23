        static IEnumerable<DriveInfo> GetUsbDevices()
        {
            IEnumerable<string> usbDrivesLetters = new ManagementObjectSearcher("select * from Win32_DiskDrive WHERE InterfaceType='USB'").Get().Cast<ManagementObject>()
                .SelectMany(drive => drive.GetRelated("Win32_DiskPartition").Cast<ManagementObject>())
                .SelectMany(o => o.GetRelated("Win32_LogicalDisk").Cast<ManagementObject>())
                .Select(i => Convert.ToString(i["Name"]) + "\\");
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                if (usbDrivesLetters.Contains(drive.RootDirectory.Name))
                    yield return drive;
            }
        }
