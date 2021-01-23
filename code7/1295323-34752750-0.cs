    DirectoryInfo directory = new DirectoryInfo(@"C:\my\directory");
    DirectorySecurity security = directory.GetAccessControl();
    
    security.AddAccessRule(new FileSystemAccessRule(@"MYDOMAIN\JohnDoe", 
    						FileSystemRights.Modify, 
    						AccessControlType.Deny));
    
    directory.SetAccessControl(security);	
