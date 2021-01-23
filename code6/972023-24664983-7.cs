    var records = new BlockingCollection<DataRecord>();
    var producer = Task.Run(() =>
    {
        try
        {
            foreach (var record in GetData("http://foo.com/Service", 22))
            {
                // Hand over the record to the
                // consumer and continue enumerating.
                records.Add(record);
            }
        }
        finally
        {
            // This needs to be called even in
            // exceptional scenarios so that the
            // consumer task does not block
            // indefinitely on the call to MoveNext.
            records.CompleteAdding();
        }
    });
    var consumer = Task.Run(() =>
    {
        foreach (var record in records.GetConsumingEnumerable())
        {
            // Do something with the record yielded by GetData.
            // This runs in parallel with the producer,
            // So you get concurrent download and processing
            // with a safe handover via the BlockingCollection.
        }
    });
    await Task.WhenAll(producer, consumer);
