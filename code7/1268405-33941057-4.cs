    public void ProcessReplicationItem(ReplicationItem replicationItem)
    {
        using (var db = new MyDbContext())
        {
            // Custom method that attempts to get remote value by Model Name and Id
            var remoteRecord = await ApiHttpConsumer.TryGetAsync(replicationItem.ModelName, replicationItem.Id);
            bool hasRemoteRecord = remoteRecord.Content != null;
            // Get to know if a local copy of this record exists.
            bool hasLocalRecord = db.HasRecord_ReflectionTest(replicationItem.ModelName, replicationItem.Id);
            // Ensure response is valid whether it is a successful get or error means something ( ie. NotFound )
            if (remoteRecord.Success || remoteRecord.ResponseCode == System.Net.HttpStatusCode.NotFound)
            {
                switch (replicationItem.Action)
                {
                    case ReplicationAction.Create:
                    {
                        if (hasRemoteRecord)
                        {
                            if (hasLocalRecord)
                                await db.UpdateByModelNameAndId(remoteRecord.Content);
                            else
                                await db.InsertByModelNameAndId(remoteRecord.Content);
                        }
                        // else - Do nothing
                        break;
                    }
                    case ReplicationAction.Update:
                        [etc...]
                }
            }
        }
    }
