    private static DirectoryEntry GetUser(string withUserAccoutName, string inOUWithDNPath)
    {
        var ouEntry = new DirectoryEntry(inOUWithDNPath);
        var searcher = new DirectorySearcher();
        searcher.SearchRoot = ouEntry;
        searcher.Filter = string.Format("(& (objectClass=User)(sAMAccountName={0}))", withUserAccoutName);
        var searchResults = searcher.FindAll();
        if (searchResults.Count > 0)
        {
            return searchResults[0].GetDirectoryEntry();
        }
        else
        {
            return null;
        }
    }
    private static bool IsGroupMember(DirectoryEntry entryToCheck, DirectoryEntry ofGroup)
    {
        foreach (var memberPath in (IEnumerable) ofGroup.Invoke("Members", null))
        {
            var memberEntry = new DirectoryEntry(memberPath);
            if (((string) memberEntry.Properties["distinguishedName"].Value).Equals(((string) entryToCheck.Properties["distinguishedName"].Value), StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }
    private static void AddUserToGroup(DirectoryEntry userToAdd, DirectoryEntry toGroup)
    {
        if (!IsGroupMember(userToAdd, toGroup))
        {
            try
            {
                toGroup.Invoke("Add", new[] { userToAdd.Path });
            }
            catch (Exception e)
            {
                throw e.InnerException; // unwrap the exception and throw that.
            }
        }
    }
