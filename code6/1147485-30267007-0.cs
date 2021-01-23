    private bool GrantAccess(string filepath)
        {
            FileInfo fInfo = new FileInfo(filepath);
            FileSecurity fSecurity = fInfo.GetAccessControl();
            fSecurity.AddAccessRule(new FileSystemAccessRule("IUSER", 
                          FileSystemRights.FullControl, 
                          AccessControlType.Allow));
            fInfo.SetAccessControl(fSecurity);
            return true;
        }
