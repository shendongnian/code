    public void Process()
    {
        Parallel.ForEach(itemCollection,
            //This is called at the creation of a thread, may be called on many threads at once.
            () =>  
            {
                lock(someConnection)
                {
                    var newConnection = someConnection.Clone();
                    return new DataUpdater(newConnection)
                }
            };
            (item, loopState, dataUpdater) => //dataUpdater is the thread local copy
            {
                ProcessItem(item, dataUpdater);
        
                // (commented as not relevant to question)
                // if (mustStop()) 
                // {
                //     loopState.Break();
                // }
                //This will get passed in to the next item or the cleanup method.
                return dataUpdater;
             }
            //This is called at the end of a thread after it has finished processing items.
            , (dataUpdater) => dataUpdater.Close() 
            );
    }
    private void ProcessItem(Item item, DataUpdater dataUpdater)
    {
        // some processing...
        dataUpdater.Update(item);
    }
