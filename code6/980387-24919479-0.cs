    DirectoryEntry dir = new DirectoryEntry("LDAP://path.local/OU=MonOU,DC=SILOGIX-ESS01,DC=local", "username", "password");
    string filter = "(&(objectCategory=person)(objectClass=user);(!userAccountControl:1.2.840.113556.1.4.803:=2)(c=CA))";
    string[] propertiesToLoad = new string[1] { "name" };
    DirectorySearcher searcher = new DirectorySearcher(dir, filter, propertiesToLoad);
    SearchResultCollection results = searcher.FindAll();
    List<string> usernames   = new List<string>();
    foreach (SearchResult result in results)
            {
                string name = (string)result.Properties["name"][0];
                if (name != null)
                    usernames.Add(name);
            }
