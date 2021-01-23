    List<SyncQueue> tempMassiveSyncQueue = new List<SyncQueue>();
    foreach(var item in massiveSyncQueue)
    {
       tempMassiveSyncQueue.Add(item);
    }
    while (tempMassiveSyncQueue.Count != 0)
    {
    int MassivePackageFileCount = Convert.ToInt32(ConfigurationManager.AppSettings["MassivePackageFileLimit"]);
    List<SyncQueue> tempMassivePackageSyncQueue=new List<SyncQueue>();
     if (massiveSyncQueues.Count > 1000
     {
         var massivePackageSyncQueue = (massiveSyncQueues.Take(1000)).ToList<SyncQueue>();
         tempMassivePackageSyncQueue = massivePackageSyncQueue;
         SubmitPackage(massivePackageSyncQueue);
     }
     if (tempMassivePackageSyncQueue.Count != 0)
     {
         foreach (var massivesynq in massiveSyncQueue)
         {
             foreach (var deleteId in tempMassivePackageSyncQueue.Where(id => id.SyncQueueId == massivesynq.SyncQueueId))
             {
                 massiveSyncQueue.Remove(massivesynq);
             }
         }
     }
     else
     {
         SubmitPackage(massiveSyncQueues);
     }
    massiveSyncQueues = null;
}
