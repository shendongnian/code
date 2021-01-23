    // Create a new DirectoryInfo object.
    DirectoryInfo directoryInfo = new DirectoryInfo(_folderPath);
    // Get a DirectorySecurity object that represents the 
    // current security settings.
    DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();
    SecurityIdentifier sidAll = new SecurityIdentifier("S-1-1-0");
    
    
    //Set the permissions for files in that folder to allow
    
    FileSystemRights rights = FileSystemRights.Modify | 
                              FileSystemRights.ReadAndExecute | 
                              FileSystemRights.ListDirectory |
                              FileSystemRights.Read |
                              FileSystemRights.Write 
    directorySecurity.AddAccessRule(
                new FileSystemAccessRule(
                    sidAll,
                    rights,
                    InheritanceFlags.ContainerInherit |
                    InheritanceFlags.ObjectInherit, 
                    PropagationFlags.None,
                    AccessControlType.Allow)
                );
    FileSystemRights subfolderRights = FileSystemRights.CreateDirectories |
                                       FileSystemRights.DeleteSubdirectoriesAndFiles |
                                       FileSystemRights.Delete;
    //Set the rights for subfolders of the 
    directorySecurity.AddAccessRule(
                new FileSystemAccessRule(
                    sidAll,
                    subfolderRights,
                    InheritanceFlags.ContainerInherit, PropagationFlags.None,
                    AccessControlType.Deny)
                );
    // Set the new access settings.
    directoryInfo.SetAccessControl(directorySecurity);
