    Sitecore.Data.Items.Item item = Sitecore.Context.Item;
    Sitecore.Diagnostics.Assert.IsNotNull(item, "item");
    Sitecore.Data.Archiving.Archive archive = 
    Sitecore.Data.Archiving.ArchiveManager.GetArchive("archive", item.Database);
      
    foreach (Sitecore.Data.Items.Item child in item.Children)
    {
      if (archive != null)
      {
        // archive the item
        archive.ArchiveItem(child);
        // to archive an individual version instead: archive.ArchiveVersion(child);
      }
      else
      {
        // recycle the item
        // no need to check settings and existence of archive
        item.Recycle();
        // to bypass the recycle bin: item.Delete();
        // to recycle an individual version: item.RecycleVersion();
        // to bypass the recycle bin for a version: item.Versions.RemoveVersion();
      }
    }
