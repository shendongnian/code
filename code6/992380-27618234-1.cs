    QueueDescription qd = new QueueDescription("MyQueue");
    qd.LockDuration = ...
    
    if (!namespaceManager.QueueExists("MyQueue"))
    {
        namespaceManager.CreateQueue(qd);
    }
