    var lockKey = clientId + clientSyncTable;
    var l = Locks.GetOrAdd(lockKey, x => new object());
    
    lock(l)
    {
        ISyncMetadataClient syncMetadataClient =
                    await SyncDataService.ClientSyncMetadata.GetFirstAsync(
                        new {
                            ClientId = clientId,
                            SyncTable = clientSyncTable
                        }).ConfigureAwait(false);
    
                if (syncMetadataClient == null)
                {
                     //your other logic
                }
    }
    // other code
