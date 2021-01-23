    DirectoryEntry entry = new DirectoryEntry(ConfigurationManager.AppSettings["LDAP"]);
    DirectorySearcher search = new DirectorySearcher(entry)
    {
        SearchScope = SearchScope.Subtree,
        Filter = "(&(objectClass=user)(physicalDeliveryOfficeName=Dartmouth))"
    };
    search.PropertiesToLoad.Add("sAMAccountName");
    SearchResultCollection result = search.FindAll();
    
    var result = result.Cast<SearchResult>().Select(sr => sr.GetDirectoryEntry())
        .Select(de => new 
        {
            Name = de.Properties["Name"] != null ? de.Properties["Name"].Value.ToString() : "",
            Phone = de.Properties["Phone"] != null ? de.Properties["Phone"].Value.ToString() : "",
            Email = de.Properties["Email"] != null ? de.Properties["Email"].Value.ToString() : "",
        }).ToList();
    
    grdvList.DataSource = result;
    grdvList.DataBind();
