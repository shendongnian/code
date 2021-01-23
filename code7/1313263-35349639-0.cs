    try
    {
           // Way safer than string comparison against "BUILTIN\\Administrators"
           IdentityReference BuiltinAdministrators = new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, null);
           IdentityReference AuthenticatedUsers = new SecurityIdentifier(WellKnownSidType.AuthenticatedUserSid, null);
    
           FileSecurity FileACL = File.GetAccessControl("database.sdf"); // Grab ACL from file
    
           if (FileACL.GetOwner(typeof(SecurityIdentifier)) != BuiltinAdministrators) // Check if correct owner is set
           {
                 FileACL.SetOwner(BuiltinAdministrators); // If not, make it so!
           }
    
           foreach (FileSystemAccessRule fsRule in FileACL.GetAccessRules(true, true, typeof(SecurityIdentifier)))
           {
                 if ((fsRule.FileSystemRights & FileSystemRights.Delete) == FileSystemRights.Delete ||
                        (fsRule.FileSystemRights & FileSystemRights.ChangePermissions) == FileSystemRights.ChangePermissions) // Check if rule grants delete or change permissions
                 {
                      FileACL.RemoveAccessRule(fsRule); // If so, nuke it!
                 }
           }
    
           // Add explicit rules
           FileACL.AddAccessRule(new FileSystemAccessRule(BuiltinAdministrators, FileSystemRights.FullControl, AccessControlType.Allow));
           FileACL.AddAccessRule(new FileSystemAccessRule(AuthenticatedUsers, FileSystemRights.Delete, AccessControlType.Deny));
           FileACL.AddAccessRule(new FileSystemAccessRule(AuthenticatedUsers, FileSystemRights.ChangePermissions, AccessControlType.Deny));
           FileACL.AddAccessRule(new FileSystemAccessRule(AuthenticatedUsers, FileSystemRights.Read, AccessControlType.Allow));
           FileACL.AddAccessRule(new FileSystemAccessRule(AuthenticatedUsers, FileSystemRights.Write, AccessControlType.Allow));
                    
           FileACL.SetAccessRuleProtection(true, false); // Enable protection from inheritance, remove existing inherited rules
           File.SetAccessControl("database.sdf", FileACL); // Write ACL back to file
       }
       catch { }
