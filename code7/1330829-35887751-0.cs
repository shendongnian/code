        foreach (var massivesynq in tempMassiveSyncQueue.ToList())
    {
    	foreach (var deleteId in tempMassivePackageSyncQueue.Where(id => id.SyncQueueId == massivesynq.SyncQueueId).ToList())
        {
            tempMassiveSyncQueue.Remove(massivesynq);
        }
    }
