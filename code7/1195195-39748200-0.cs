    static class ComACLRights
    {
        public const int COM_RIGHTS_EXECUTE = 1;
        public const int COM_RIGHTS_EXECUTE_LOCAL = 2;
        public const int COM_RIGHTS_EXECUTE_REMOTE = 4;
        public const int COM_RIGHTS_ACTIVATE_LOCAL = 8;
        public const int COM_RIGHTS_ACTIVATE_REMOTE = 16;
    }
    static void Main(string[] args)
    {
         SetCOMSercurityAccess("testuser", "DefaultAccessPermission");
         SetCOMSercurityAccess("testuser", "DefaultLaunchPermission");
    }
    private static void SetCOMSercurityAccess(string username, string regKey)
    {
        //Get sid from username
        NTAccount f = new NTAccount(username);
        SecurityIdentifier sid = (SecurityIdentifier)f.Translate(typeof(SecurityIdentifier));
            
        //Read reg key responsible for COM Sercurity
        var accessKey = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Ole", regKey, null);
        RawSecurityDescriptor sd;
        if (accessKey == null)
        {
            //Key does not exist
            sd = new RawSecurityDescriptor("");
        }
        else
        {
            //read security settings
            sd = new RawSecurityDescriptor(accessKey as byte[], 0);
        }
        //Look fo input foruser
        var acl = sd.DiscretionaryAcl;
        var found = false;
        foreach (CommonAce ca in acl)
        {
            if (ca.SecurityIdentifier == sid)
            {
                //ensure local access is set
                ca.AccessMask |= ComACLRights.COM_RIGHTS_EXECUTE | ComACLRights.COM_RIGHTS_EXECUTE_LOCAL | ComACLRights.COM_RIGHTS_ACTIVATE_LOCAL;    //set local access.  Always set execute
                found = true;
                break;
            }
        }
        if (!found)
        {
            CommonAce ca = new CommonAce(
                AceFlags.None,
                AceQualifier.AccessAllowed,
                ComACLRights.COM_RIGHTS_EXECUTE | ComACLRights.COM_RIGHTS_EXECUTE_LOCAL | ComACLRights.COM_RIGHTS_ACTIVATE_LOCAL,
                    sid,
                    false,
                    null);
            acl.InsertAce(acl.Count, ca);
        }
        //re-set the ACL
        sd.DiscretionaryAcl = acl;
        //Convert back to binary and save
        byte[] binaryform = new byte[sd.BinaryLength];
        sd.GetBinaryForm(binaryform, 0);
        Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Ole", regKey, binaryform, RegistryValueKind.Binary);
    }
