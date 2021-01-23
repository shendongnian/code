    using System.Management;
    public static String UNC2LocalPath(String input)
    {
        DriveInfo[] dis = DriveInfo.GetDrives();
        foreach (DriveInfo di in dis)
        {
            if (di.DriveType == DriveType.Network)
            {
                DirectoryInfo dir = di.RootDirectory;
                var unc = GetUNCPath(dir.FullName.Substring(0, 2));
                if (input.StartsWith(unc_path, StringComparison.OrdinalIgnoreCase))
                {
                    return input.Replace(Path.GetPathRoot(unc) + "\\", dir.FullName);
                }
            }                
        }
        return null;
    }
    public static string GetUNCPath(string path)
    {
        if (path.StartsWith(@"\\"))
            return path;
    
        ManagementObject mo = new ManagementObject();
        mo.Path = new ManagementPath(string.Format("Win32_LogicalDisk='{0}'", path));
    
        //DriveType 4 = Network Drive
        if (Convert.ToUInt32(mo["DriveType"]) == 4)
            return Convert.ToString(mo["ProviderName"]);
        else return path;
    }
