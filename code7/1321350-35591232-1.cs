    using (new SecurityDisabler())
    {
        DateTime archiveDate = new DateTime(2015, 9, 8);
        string pathPrefix = "/sitecore/media library";
     
        // get the recyclebin for the master database
        Sitecore.Data.Archiving.Archive archive = Sitecore.Data.Database.GetDatabase("master").Archives["recyclebin"];
     
        // get as many deleted items as possible 
        // where the archived date is after a given date 
        // and the item path starts with a given path
        var itemsRemovedAfterSomeDate =
            archive.GetEntries(0, int.MaxValue)
                    .Where(entry => 
                        entry.ArchiveDate > archiveDate && 
                        entry.OriginalLocation.StartsWith(pathPrefix)
                    ).ToList();
     
        foreach (var itemRemoved in itemsRemovedAfterSomeDate)
        {
            // restore the item
            archive.RestoreItem(itemRemoved.ArchivalId);
        }
    }
