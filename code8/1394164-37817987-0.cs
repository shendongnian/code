     string _Path = string.Empty;
     SearchResult results = null;
     using (var rootDse = new DirectoryEntry("LDAP://rootDSE"))
            {
                if (null != rootDse)
                {
                    string path = string.Format("LDAP://{0}", rootDse.Properties["defaultNamingContext"][0]);
                    using (var de = new DirectoryEntry(path))
                    {
                        using (var search = new DirectorySearcher(de)
                        {
                            Filter = "(&(objectClass=user)(sAMAccountName=username))"
                        })
                        {
                            search.PropertiesToLoad.Add("DisplayName");
                            search.PropertiesToLoad.Add("mail");
                            results = search.FindOne();
                            if (null != results)
                                _Path = results.Path;
                        };
                    }
                }
            }
     
     using (var entry = new DirectoryEntry(_Path))
            {
                using (var search = new DirectorySearcher(entry))
                {
                    return search.FindOne();
                }
            }
