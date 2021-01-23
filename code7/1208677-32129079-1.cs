    public static IEnumerable<Address> GetGlobalAddressList()
    {
        using (var searcher = new DirectorySearcher())
        {
            using (var entry = new DirectoryEntry(searcher.SearchRoot.Path, "*****", "*****"))
            {
                searcher.Filter = "(&(mailnickname=*)(objectClass=user))";
                searcher.PropertiesToLoad.Add("cn");
                searcher.PropertyNamesOnly = true;
                searcher.SearchScope = SearchScope.Subtree;
                searcher.Sort.Direction = SortDirection.Ascending;
                searcher.Sort.PropertyName = "cn";
               
                foreach (SearchResult i in searcher.FindAll())
                {
                    var address = new Address
                    {
                        DisplayName = (string)i.GetDirectoryEntry().Properties["displayName"].Value,
                        Mail = (string) i.GetDirectoryEntry().Properties["mail"].Value
                    };
                    yeild return address;
                }
            }
        }
    }
