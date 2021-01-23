    //Switched to a thread safe collection.
    var documents = new ConcurrentQueue<ExtractedContent>();
    using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
    {
        var attachments = await dao.GetAttachmentsAsync();
        //Grab a reference to the current transaction.
        var transaction = Transaction.Current;
        Parallel.ForEach(attachments, a =>
        {
            //Spawn a dependant clone of the transaction
            using (var depTs = transaction.DependentClone(DependentCloneOption.RollbackIfNotComplete))
            {
                documents.Enqueue(a.ToDbDocument());
                depTs.Complete();
            }
        });
        ts.Complete();
    }
