    using (System.DirectoryServices.DirectoryEntry de = (System.DirectoryServices.DirectoryEntry)user.GetUnderlyingObject())
    {
        int i = -1;
        if (de != null && ((i = de.Path.IndexOf("//")) != -1))
        {
            string protocol = de.Path.Substring(0, i + 2);
            usr.Domain = protocol + user.Context.Name; // + "/" + user.Context.Container;
        } // End if (de != null) 
        else
        {
            if ((user.Context.Options & System.DirectoryServices.AccountManagement.ContextOptions.SecureSocketLayer) != 0)
            {
                usr.Domain = "LDAPS://" + user.Context.Name; // + "/" + user.Context.Container;
            }
            else
            {
                usr.Domain = "LDAP://" + user.Context.Name; // + "/" + user.Context.Container;
            }
        }
    } // End Using de 
