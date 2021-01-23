    var timeout = TimeSpan.FromSeconds(5);
    var lockKey = clientId + clientSyncTable;
    RedisValue lockId = Guid.NewGuid().ToString();
    if(await cache.LockTakeAsync(lockKey, lockId, timeout)) { //note that obtaining a distributed lock may fail
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
        } finally {
            await cache.LockReleaseAsync(key, lockId); //release the same lock
        }
    }
