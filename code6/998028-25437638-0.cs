    // Track whether there are more items available for download on the server.
    bool moreChangesAvailable = false;
    do {
        // Get a list of all items in the Inbox by calling SyncFolderHierarchy repeatedly until no more changes are available.
        // The folderId parameter must be set to the root folder to synchronize,
        // and must be same folder ID as used in previous synchronization calls. 
        // The propertySet parameter is set to IdOnly to reduce calls to the Exchange database,
        // because any additional properties result in additional calls to the Exchange database. 
        // The ignoredItemIds parameter is set to null, so that no items are ignored.
        // The maxChangesReturned parameter is set to return a maximum of 10 items (512 is the maximum).
        // The syncScope parameter is set to Normal items, so that associated items will not be returned.
        // The syncState parameter is set to cSyncState, which should be null in the initial call, 
        // and should be set to the sync state returned by the 
        // previous SyncFolderItems call in subsequent calls.
        ChangeCollection<ItemChange> icc = service.SyncFolderItems(new FolderId(WellKnownFolderName.Inbox), PropertySet.IdOnly, null, 10, SyncFolderItemsScope.NormalItems, cSyncState);
        // If the count of changes is zero, there are no changes to synchronize.
        if (icc.Count <> 0) {
            // Otherwise, write all the changes included in the response to the console. 
            foreach (ItemChange ic in icc) {
                Console.WriteLine("ChangeType: " + ic.ChangeType.ToString());
                Console.WriteLine("ItemId: " + ic.ItemId);
            }
        }
        // Save the sync state for use in future SyncFolderContent requests.
        // The sync state is used by the server to determine what changes to report
        // to the client.
        string sSyncState = icc.SyncState;
       // Determine whether more changes are available on the server.
       moreChangesAvailable = icc.MoreChangesAvailable;
    }
    while (moreChangesAvailable);
