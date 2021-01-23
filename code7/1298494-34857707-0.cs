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
            (item, loopState, dataUpdater) =>
            {
                ProcessItem(item, dataUpdater);
        
                // (commented as not relevant to question)
                // if (mustStop()) 
                // {
                //     loopState.Break();
                // }
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
