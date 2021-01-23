    var lockKey = clientId + clientSyncTable;
    var sem = Locks.GetOrAdd(lockKey, x => new SemaphoreSlim(1));
    await sem.WaitAsync();
    try {
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
    finally {
        sem.Release();
    }
    // other code
