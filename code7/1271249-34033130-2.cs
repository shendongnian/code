    using System.DirectoryServices;
    
    public IEnumerable<DirectoryEntry> GetUsersFromGroups(string[] groupNames)
    {
        if (groupNames.Length > 0)
        {
            var searcher = new DirectorySearcher();
            string searchFilter = "(&(objectClass=Group)"; //filter for groups
            searchFilter += "(|"; //start a group of or parameters
            foreach (var group in groupNames) //loop through the group names
            {
                searchFilter += string.Format("(SAMAccountName={0})",group); //add a parameter for each group in the list
            }
            searchFilter += "))"; //close off the filter string
            searcher.PropertiesToLoad.Add("member"); // load the members property for the group
            var searchResults = searcher.FindAll(); // perform the search
            foreach (SearchResult result in searchResults)
            {
                var directoryEntry = (DirectoryEntry)result.GetDirectoryEntry(); // get the directory entry for the group
                PropertyValueCollection members = directoryEntry.Properties["member"]; // get the members collection
                foreach (string name in members) iterate through the members.  this string will be the distinguished name
                {
                    yield return new DirectoryEntry(string.Format("LDAP://{0}",g"); //return the directory entry.  you may get the entry and return the display name or just return distinguished name.
                }
            }
        }    
    }
