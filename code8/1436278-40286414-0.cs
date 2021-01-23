    public static void ForceChangeADPassword(String username, String newPassword)
    {
        String DN = "";
        try
        {
            DN = GetObjectDistinguishedName(objectClass.user, returnType.distinguishedName, username, DOMAIN_CONTROLLER_IP);
        }
        catch(Exception e)
        {
            throw new PasswordException(String.Format("Could not find AD User {0}", username), e);
        }
        if(DN.Equals(""))
            throw new PasswordException(String.Format("Could not find AD User {0}", username));
        DirectoryEntry userEntry = new DirectoryEntry(DN.Replace("LDAP://", LdapRootPath), "accounts", AcctPwd);
        userEntry.Invoke("SetPassword", new object[] { newPassword });
        userEntry.Properties["LockOutTime"].Value = 0;
        userEntry.CommitChanges();
        userEntry.Close();
    }
