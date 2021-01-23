    public void SetFolderPermission(string folderPath,string account,string server)
    {
       var directoryInfo = new DirectoryInfo(folderPath);
       var directorySecurity = directoryInfo.GetAccessControl();
       PrincipalContext pt = new PrincipalContext(ContextType.Machine, server);
       
        using (GroupPrincipal val = GroupPrincipal.FindByIdentity(pt, account))
    {
  
        FileSystemAccessRule fileSystemRule = new FileSystemAccessRule(val.Sid,
                                                         FileSystemRights.Read,
                                                         InheritanceFlags.ObjectInherit |
                                                         InheritanceFlags.ContainerInherit,
                                                         PropagationFlags.None,
                                                         AccessControlType.Allow);//var
        directorySecurity.AddAccessRule(fileSystemRule);
        directoryInfo.SetAccessControl(directorySecurity);
        MessageBox.Show("done");
    }
    }
      
