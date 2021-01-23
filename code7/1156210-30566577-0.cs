                    byte[] DaclByte = (Byte[])DirectoryEntry.Properties["msExchMailBoxSecurityDescriptor"][0];
                    System.DirectoryServices.ActiveDirectorySecurity adDACL = new ActiveDirectorySecurity();
                    adDACL.SetSecurityDescriptorBinaryForm(DaclByte);
                    System.Security.AccessControl.AuthorizationRuleCollection aclCollection = adDACL.GetAccessRules(true, false, typeof(System.Security.Principal.SecurityIdentifier));
                    foreach (System.Security.AccessControl.AuthorizationRule ace in aclCollection)
                    {
