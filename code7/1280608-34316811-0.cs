    var search = new DirectorySearcher();            
    search.Filter = "(&(objectClass=user)(mail=*)(displayName=*))";
    search.PageSize = 1000;  // see 1.
    using (var results = searcher.FindAll()) {  // see 2.
        foreach (var result in results)
        {
            emailAddresses.Add(new EmailDetails
            {
                EmailAddress = result.Properties["mail"][0].ToString(),
                EmailDisplayName = result.Properties["displayName"][0].ToString()
            });
        }
    }
