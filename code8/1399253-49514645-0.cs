    public static void SetGroupUsersPermission(string Path,string groupname)
    {
        DirectoryInfo dirInfo = new DirectoryInfo(Path);
        
        DirectorySecurity dirSec = dirInfo.GetAccessControl();
         dirSec.AddAccessRule(new FileSystemAccessRule(Environment.UserDomainName + @"\" +
         groupname, FileSystemRights.FullControl, AccessControlType.Allow));
         dirInfo.SetAccessControl(dirSec);
    }
