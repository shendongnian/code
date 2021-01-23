    public static string GetSerialFromDrive(string driveLetter)
    {
        try
        {
            using (var partitions = new ManagementObjectSearcher("ASSOCIATORS OF {Win32_LogicalDisk.DeviceID='" + driveLetter +
                                                "'} WHERE ResultClass=Win32_DiskPartition"))
            {
                foreach (var partition in partitions.Get())
                {
                    using (var drives = new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" +
                                                            partition["DeviceID"] +
                                                            "'} WHERE ResultClass=Win32_DiskDrive"))
                    {
                        foreach (var drive in drives.Get())
                        {
                            return (string)drive["SerialNumber"];
                        }
                    }
                }
            }
        }
        catch
        {
            return "<unknown>";
        }
    
        // Not Found
        return "<unknown>";
    }
