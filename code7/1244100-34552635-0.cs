        // Search Active Directory users.
        public static IEnumerable<DirectoryEntry> SearchActiveDirectoryUsers(string searchKeyword)
        {
            // Escape special characters in the search string.
            string escapedSearchKeyword = searchKeyword.Replace("*", "\\2a").Replace("(", "\\28").Replace(")", "\\29").Replace("/", "\\2f").Replace("\\", "\\5c");
            // Find entries where searchKeyword appears in ANY of the following fields (you can add or remove fields to suit your needs).
            // The '|' characters near the start of the expression means "any".
            string searchPropertiesExpression = string.Format("(|(sn=*{0}*)(givenName=*{0}*)(cn=*{0}*)(dn=*{0}*)(samaccountname=*{0}*))", escapedSearchKeyword);
            // Only want users
            string filter = "(&(objectCategory=Person)(" + searchPropertiesExpression + "))"; 
            using (DirectoryEntry gc = new DirectoryEntry("GC:"))
            {
                foreach (DirectoryEntry root in gc.Children)
                {
                    try
                    {
                        using (DirectorySearcher searcher = new DirectorySearcher(root, filter))
                        {
                            searcher.ReferralChasing = ReferralChasingOption.All;
                            SearchResultCollection results = searcher.FindAll();
                            foreach (SearchResult sr in results)
                            {
                                using (DirectoryEntry directoryEntry = sr.GetDirectoryEntry())
                                {
                                    yield return directoryEntry;
                                }
                            }
                        }
                    }
                    finally
                    {
                        root.Dispose();
                    }
                }
            }
