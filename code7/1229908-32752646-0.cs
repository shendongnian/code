     lock(syncObject)
     {
        myQueue.Enqueue(..);
     }
     ... in another method
     lock (syncObject)
     {
        myQueue.Peek(...);
        ...
        myQueue.Dequeue(...);
     }
     
