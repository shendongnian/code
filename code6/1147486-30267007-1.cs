    private bool RemoveAccess(string filepath)
        {
            FileInfo fInfo = new FileInfo(filepath);
            FileSecurity fSecurity = fInfo.GetAccessControl();
            fSecurity.AddAccessRule(
                  new FileSystemAccessRule("IUSER", 
                          FileSystemRights.FullControl, 
                          AccessControlType.Deny));
            fInfo.SetAccessControl(fSecurity);
            return true;
        }
