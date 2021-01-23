    string MMF_Name = @"Global\MyMemoryMappedFileName";
    var security = new MemoryMappedFileSecurity();
    security.AddAccessRule(new System.Security.AccessControl.AccessRule<MemoryMappedFileRights>(new SecurityIdentifier(WellKnownSidType.WorldSid, null), MemoryMappedFileRights.FullControl, AccessControlType.Allow));
    var mmf = MemoryMappedFile.CreateOrOpen(MMF_Name
        , 1024 * 1024
        , MemoryMappedFileAccess.ReadWrite
        , MemoryMappedFileOptions.None
        , security
        , System.IO.HandleInheritability.Inheritable);
