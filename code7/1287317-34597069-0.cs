    string subpath = "CN=something, CN=com"; // CNs appropriate to your environment here
    string filter = ""; // append additional LDAP filter parameters as necessary
    // build LDAP filter query
    DateTime date = DateTime.UtcNow;
    date.AddDays(-30);
    string LDAPQuery = "(&(whenCreated>="+date.ToString("YYYYMMdd")+"000000.0Z)" + filter + ")";    
    // get DNS host name
    DirectoryEntry entry = new DirectoryEntry("LDAP://RootDSE");
    Object value = entry.NativeObject;
    string dnsHostName = entry.Properties["dnsHostName"].value.ToString();
    // search Active Directory
    DirectorySearcher searcher = new DirectorySearcher();
    searcher.Filter = LDAPQuery;
    searcher.SearchRoot = new DirectoryEntry("LDAP://"+dnsHostName+"/"+subpath);
    SearchResultCollection results = searcher.FindAll();
    // then iterate through results and 
    // either display them on a page or create items in a list
