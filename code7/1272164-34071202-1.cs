    Task.Factory.StartNew(() =>
    {
        foreach (string file in this.documents.GetConsumingEnumerable())
        {
            // process file
        }
    },
    TaskCreationOptions.LongRunning
    );
