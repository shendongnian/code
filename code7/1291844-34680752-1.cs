    ...    
    AllGroupUsers = ds.FindAll();
    if (AllGroupUsers.Count > 0) {
        ResultPropertyValueCollection values = AllGroupUsers[0].Properties["member"];
        foreach (string s in values) 
        {
            DirectoryEntry u = new DirectoryEntry("LDAP://" + s);  
            Console.WriteLine(u.Properties["displayName"].Value);
        }
    }
