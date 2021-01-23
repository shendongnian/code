    namespace ADM
    {
        class GetterSevice
        {
            static string path = "LDAP://DC=testdomain, DC=com";
            static DirectoryEntry DE = new DirectoryEntry(path, null, null, AuthenticationTypes.Secure);
            DirectorySearcher ds = new DirectorySearcher(DE, "objectClass=User", null, SearchScope.Subtree);
    
            public string getUsername(string username)
            {
    
                string finalResult = "";
    
                
                ds.Filter = "(&((&(objectClass=User)(objectCategory=person)))(SAMAccountName=" + username + "))";
    
                SearchResultCollection src = ds.FindAll();
    
                foreach (SearchResult sr in src)
                {
                    DirectoryEntry result = new DirectoryEntry();
                    result = new DirectoryEntry(sr.Path);
                    finalResult = (result.InvokeGet("SAMAccountName")).ToString();
                }
    
    
                return finalResult;
            }
