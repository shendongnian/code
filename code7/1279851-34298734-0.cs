    using (DirectoryEntry entry = new DirectoryEntry("LDAP://" + Environment.UserDomainName))
    {
        using (DirectorySearcher searcher = new DirectorySearcher(
            entry,
            string.Format(
                "(&(objectCategory=person)(objectClass=user)(displayName={0}*)(memberof={1}))",
                displayNameQuery,
                groupName)))
        {
            searcher.PropertiesToLoad.Add("samAccountname"); //You can specify which properties you want to load. If you don't specify properties, by default you will get a lot of properties. Loading specific properties is better in terms of performance
            using (var results = searcher.FindAll())
            {
                foreach (var result in results.Cast<SearchResult>())
                {
                    //Do something with result
                    var properties = result.Properties;
                    //Example
                    var samAccountName = properties["samAccountName"][0];
                    //...
                }
            }
        }
    }
