    DirectoryInfo dInfo;
    DirectorySecurity dSecurity = dInfo.GetAccessControl();
    dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.InheritOnly, AccessControlType.Allow));
    dInfo.SetAccessControl(dSecurity);
    
