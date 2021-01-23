        using (DirectorySearcher searcher = new DirectorySearcher(new DirectoryEntry("LDAP://someserver:123/OU=d-users,DC=domain,DC=x,DC=y,DC=com")))
                    {
                        StringBuilder filterStringBuilder = new StringBuilder();
                        // Just create a single LDAP query for all user SIDs
                        filterStringBuilder.Append("(&(objectClass=user)(|");
                        filterStringBuilder.AppendFormat("({0}={1})", "sAMAccountName", AccountName);
                        filterStringBuilder.Append("))");
                        searcher.PageSize = 1000; // Very important to have it here. Otherwise you'll get only 1000 at all. Please refere to DirectorySearcher documentation
        
                        searcher.Filter = filterStringBuilder.ToString();
                        searcher.ReferralChasing = ReferralChasingOption.None;
        
                        searcher.PropertiesToLoad.AddRange(
                            new[] { "DistinguishedName" });
        
                        var result = searcher.FindOne();
                     }
