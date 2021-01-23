    string domainPath = String.Format("LDAP://{0},DC=site,DC=com", domain);
    using (DirectoryEntry searchRoot = new DirectoryEntry(domainPath))
    {
        using (DirectorySearcher search = 
                filterSearch(new DirectorySearcher(searchRoot), username))
        {
            SearchResult result = null;
            
            try
            {
                result = search.FindOne();
            }
            catch (DirectoryServicesCOMException e)
            {
                //handle the error
            }
            if (result != null)
            {
                string givenname = result.Properties["givenname"].Count > 0 ? 
                        (string)result.Properties["givenname"][0] : "";
                string sn = result.Properties["sn"].Count > 0 ? 
                        (string)result.Properties["sn"][0] : "";
                        
                var samaccount= result.Properties["samaccountname"].Count > 0 ? 
                        (string)result.Properties["samaccountname"][0] : "";
                var name = String.Format("{0}, {1}", sn, givenname);
                var email = result.Properties["mail"].Count > 0 ? 
                        (string)result.Properties["mail"][0] : "";
            }
        }
    }
    //Apply a filter to search only specific classes and categories.
    //Add the specific properties to be retrieved
    private DirectorySearcher filterSearch(DirectorySearcher search, string username)
    {
        DirectorySearcher filteredSearch = search;
        filteredSearch.Filter = "(&(objectClass=user)(objectCategory=person)(samaccountname=" + username + "))";
        filteredSearch.PropertiesToLoad.Add("givenname");
        filteredSearch.PropertiesToLoad.Add("sn");
        filteredSearch.PropertiesToLoad.Add("samaccountname");
        filteredSearch.PropertiesToLoad.Add("department");
        filteredSearch.PropertiesToLoad.Add("physicalDeliveryOfficeName");
        filteredSearch.PropertiesToLoad.Add("mail");
        return filteredSearch;
    }
