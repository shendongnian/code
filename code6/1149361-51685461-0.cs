    public DateTime? FindLatestLogonDate(string username)
    {
        var logons = new List<DateTime>();
        DomainControllerCollection domains = Domain.GetCurrentDomain().DomainControllers;
        foreach (DomainController controller in domains)
        {
            using (var directoryEntry = new DirectoryEntry($"LDAP://{controller.Name}"))
            {
                using (var searcher = new DirectorySearcher(directoryEntry))
                {
                    searcher.PageSize = 1000;
                    searcher.Filter = $"((sAMAccountName={username}))";
                    searcher.PropertiesToLoad.AddRange(new[] { "lastLogon" });
                    foreach (SearchResult searchResult in searcher.FindAll())
                    {
                        if (!searchResult.Properties.Contains("lastLogon")) continue;
                        var lastLogOn = DateTime.FromFileTime((long)searchResult.Properties["lastLogon"][0]);
                        logons.Add(lastLogOn);
                    }
                }
            }
        }
        return logons.Any() ? logons.Max() : (DateTime?)null;
    }
