            DirectoryEntry myLdapConnection = new DirectoryEntry("LDAP://YouDomainName");
            DirectorySearcher search = new DirectorySearcher(myLdapConnection) { Filter = ("(objectClass=user)") };
            search.CacheResults = true;
            SearchResultCollection allResults = search.FindAll();
            DataTable resultsTable = new DataTable();
            resultsTable.Columns.Add("UserID");
            resultsTable.Columns.Add("EmailID");
            foreach (SearchResult searchResult in allResults)
            {
                MembershipUser myUser = Membership.GetAllUsers()[searchResult.Properties["sAMAccountName"][0].ToString()];
                if (myUser == null)
                {
                    DataRow dr = resultsTable.NewRow();
                    dr["UserID"] = searchResult.Properties["sAMAccountName"][0].ToString();
                    if (searchResult.Properties["mail"].Count > 0)
                    {
                        dr["EmailID"] = searchResult.Properties["mail"][0].ToString();
                    }
                    else
                    {
                        dr["EmailID"] = "";
                    }
                    resultsTable.Rows.Add(dr);
                }
                else
                { }
            }
