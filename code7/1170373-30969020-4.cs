    using (DirectoryEntry dirEntry = new DirectoryEntry(ldapPath))
    {
        if (dirEntry.SchemaEntry.Name == "container")
        {
            using (DirectoryEntry newUser = dirEntry.Children.Add("CN=" + username, "User"))
            {
                 fullname = fname + " " + lname;
                 newUser.Properties["sAMAccountName"].Value = username;
                 newUser.Properties["givenName"].Value = fname;  // first name
                 newUser.Properties["sn"].Value = lname;    // surname = last name
                 newUser.Properties["displayName"].Value = fullname;  
                 newUser.Properties["password"].Value = password;
            
                 newUser.CommitChanges();
             }
        }
    }
