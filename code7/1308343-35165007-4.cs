    var changeList = new PackageHistory(devicePackageHistory);
    foreach (var databasePkgKvp in databasePackageHistory)
    {
        var changeListEntries = new List<Tuple<string, DateTime>>();
        if (changeList.TryGetValue(databasePkgKvp.Key, out changeListEntries))
        {
            foreach (var databaseEntry in databasePkgKvp.Value)
            {
                changeListEntries.Remove(databaseEntry);
            }
            if (changeListEntries.Count == 0)
            {
                changeList.Remove(databasePkgKvp.Key);
            }
        }
    }
