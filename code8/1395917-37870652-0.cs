    public async Task TryToBeginSomeProcess()
    {
        lock (someLock)
        {
            if (onlyOneTask == null)
            {
                onlyOneTask = DoSomethingButOnlyOneAtATime();
            }
            //does not compile
            await onlyOneTask;
        }
    }
