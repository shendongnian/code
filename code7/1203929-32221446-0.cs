    ...
    using (DirectoryEntry dom = new DirectoryEntry("LDAP://domainB.company.com/OU=MyOU,DC=domainB,DC=company,DC=com", "techUser1", "pass"))
    {
        using (DirectorySearcher searcher = new DirectorySearcher(dom))
        {
            searcher.Filter = "(&(objectClass=user)(CN=theUserIWantToAdd))";
            SearchResult result = searcher.FindOne();
            de.Invoke("Add", new object[] { result.Path });
        }
    }
    ...
     
