    static private void GetChangedItems()
    {
        // Path to cookie
        string syncStateFileName = @"c:\temp\ewssyncstate.txt";
        try
        {
            var service = GetServiceAP();
            bool moreChangesAvailable = false;
            do
            {
                string syncState = null;
                if (File.Exists(syncStateFileName))
                {
                    // Read cookie
                    syncState = File.ReadAllText(syncStateFileName);
                }
                ChangeCollection<ItemChange> icc = service.SyncFolderItems(new FolderId(WellKnownFolderName.Calendar), PropertySet.FirstClassProperties, null, 10, SyncFolderItemsScope.NormalItems, syncState);
                if (icc.Count == 0)
                {
                    Console.WriteLine("There are no item changes to synchronize.");
                }
                else
                {
                    syncState = icc.SyncState;
                    // Save cookie
                    File.WriteAllText(syncStateFileName, syncState);
                    moreChangesAvailable = icc.MoreChangesAvailable;
                    // Only get appointments that were created since last call
                    var createdItems = icc
                        .Where(i => i.ChangeType == ChangeType.Create)
                        .Select(i => i.Item as Appointment)
                        ;
                    if (createdItems.Any())
                    {
                        service.LoadPropertiesForItems(createdItems, PropertySet.FirstClassProperties);
                        foreach (Appointment appointment in createdItems)
                        {
                            Console.WriteLine(appointment.Subject);
                        }
                    }
                }
            }
            while (moreChangesAvailable);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
