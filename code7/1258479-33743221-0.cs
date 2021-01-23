    // what is
    var existingACL = Directory.GetAccessControl(path);
    // remove everything from what is
    foreach (FileSystemAccessRule rule in existingACL.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount)))
            existingACL.RemoveAccessRuleAll(rule);
    // add yours to what is           
    existingACL.AddAccessRule (fsRule);
    // set again
    Directory.SetAccessControl(path, existingACL);
