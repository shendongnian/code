      public string GetUserDetails(string UserID)
        {
            try
            {
                ArrayList arrlist = new ArrayList();
                DirectorySearcher search = default(DirectorySearcher);
                DirectoryEntry entry = default(DirectoryEntry);
                SearchResult sr = default(SearchResult);
                System.DirectoryServices.PropertyCollection propertycol = default(System.DirectoryServices.PropertyCollection);
                entry = new DirectoryEntry("LDAP://DomainName.com");
                propertycol = entry.Properties;
                search = new DirectorySearcher(entry);
                search.Filter = "(sAMAccountName=" + UserID + ")";                
                sr = search.FindOne();
                string fname = "";
                string lname = "";
               
                if ((sr != null))
                {
                    if (sr.Properties.Count > 1)
                    {
                        fname = Convert.ToString(sr.GetDirectoryEntry().Properties["givenName"].Value);
                        lname = Convert.ToString(sr.GetDirectoryEntry().Properties["sn"].Value);
                    }
                    return fname + "\n" + lname ;
                }
              return "User Id not found";
            }
            catch (Exception ex)
            {
                return "Error:" + ex.Message;
            }
        }
