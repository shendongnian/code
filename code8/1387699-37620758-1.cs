    public async Task RunOperations()
    {
        List<Task> pendingOperations = new List<Task>();
        for (int i=0; i<3; i++)
        {
            var op = InitiateStagedOperation(i);
            pendingOperations.Add(ProcessStagedOperation(op, i));
        }
        await Task.WhenAll(pendingOperations); // finish
    }
