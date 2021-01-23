    int count=1;
    while(tempMassivePackageSyncQueue.Count>1000)
    {
    
    
    	var massivePackageSyncQueue = (massiveSyncQueues.skip(count*1000).Take(1000)).ToList<SyncQueue>();
             tempMassivePackageSyncQueue = massivePackageSyncQueue;
    
             SubmitPackage(massivePackageSyncQueue);
    	count++;
    
    }
    var massivePackageSyncQueue = (massiveSyncQueues.skip(count*1000).Take()).ToList<SyncQueue>();
             tempMassivePackageSyncQueue = massivePackageSyncQueue;
    
             SubmitPackage(massivePackageSyncQueue);
