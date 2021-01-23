        // Search Active Directory users.
        public static IEnumerable<DirectoryEntry> SearchADUsers(string search) {
            // Escape special characters in the search string.
            string escapedSearch = search.Replace("*", "\\2a").Replace("(", "\\28")
                .Replace(")", "\\29").Replace("/", "\\2f").Replace("\\", "\\5c");
            // Find entries where search string appears in ANY of the following fields
            // (you can add or remove fields to suit your needs).
            // The '|' characters near the start of the expression means "any".
            string searchPropertiesExpression = string.Format(
                "(|(sn=*{0}*)(givenName=*{0}*)(cn=*{0}*)(dn=*{0}*)(samaccountname=*{0}*))",
                escapedSearch);
            // Only want users
            string filter = "(&(objectCategory=Person)(" + searchPropertiesExpression + "))"; 
            using (DirectoryEntry gc = new DirectoryEntry("GC:")) {
                foreach (DirectoryEntry root in gc.Children) {
                    try {
                        using (DirectorySearcher s = new DirectorySearcher(root, filter)) {
                            s.ReferralChasing = ReferralChasingOption.All;
                            SearchResultCollection results = s.FindAll();
                            foreach (SearchResult result in results) {
                                using (DirectoryEntry de = result.GetDirectoryEntry()) {
                                    yield return de;
                                }
                            }
                        }
                    } finally {
                        root.Dispose();
                    }
                }
            }
        }
