    // Way safer than string comparison against "BUILTIN\\Administrators"
    IdentityReference BuiltinAdministrators = new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, null);
    // Grab ACL from file
    FileSecurity FileACL = File.GetAccessControl(TargetFilePath);
    // Check if correct owner is set
    if (FileACL.GetOwner(typeof(SecurityIdentifier)) != BuiltinAdministrators)
    {
        // If not, make it so!
        FileACL.SetOwner(BuiltinAdministrators);
    }
    foreach (FileSystemAccessRule fsRule in FileACL.GetAccessRules(true, false, typeof(SecurityIdentifier)))
    {
        // Check if rule grants delete
        if ((fsRule.FileSystemRights & FileSystemRights.Delete) == FileSystemRights.Delete)
        {
            // If so, nuke it!
            FileACL.RemoveAccessRule(fsRule);
        }
    }
    // Add a single explicit rule to allow FullControl
    FileACL.AddAccessRule(new FileSystemAccessRule(BuiltinAdministrators, FileSystemRights.FullControl, AccessControlType.Allow));
    // Enable protection from inheritance, remove existing inherited rules
    FileACL.SetAccessRuleProtection(true, false);
    // Write ACL back to file
    File.SetAccessControl(TargetFilePath, FileACL);
