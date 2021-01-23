    static void Main(string[] args)
    {
        var filePath = "C:\\test.csv";
        var chunkSize = 1024;
        var batchSize = 128;
    
        var linkCompletion = new DataflowLinkOptions
        {
            PropagateCompletion = true
        };
    
        var uploadData = new ActionBlock<IEnumerable<string>>(
            async (data) =>
            {
                WebClient client = new WebClient();
                var payload = data.SelectMany(x => x).ToArray();
                byte[] bytes = System.Text.Encoding.ASCII.GetBytes(payload);
                //await client.UploadDataTaskAsync("myserver.com", bytes);
                await Task.Delay(2000);
            }, new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = DataflowBlockOptions.Unbounded /* Prefer to limit that to some reasonable value */ });
    
        var lineBuffer = new BatchBlock<string>(chunkSize);
    
        var splitData = new TransformManyBlock<IEnumerable<string>, IEnumerable<string>>(
            (data) =>
            {
                // Partition each chunk into smaller chunks grouped on column 1
                var partitions = data.GroupBy(c => c.Split(',')[0]);
    
                // Further beakdown the chunks into batch size groups
                var groups = partitions.Select(x => x.Select((i, index) => new { i, index }).GroupBy(g => g.index / batchSize, e => e.i));
    
                // Get batches from groups
                var batches = groups.SelectMany(x => x).Select(y => y.Select(z => z));
    
                // Don't forget to enumerate before returning
                return batches.ToList();
            }, new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = DataflowBlockOptions.Unbounded });
        lineBuffer.LinkTo(splitData, linkCompletion);
        splitData.LinkTo(uploadData, linkCompletion);
    
        foreach (var line in File.ReadLines(filePath))
        {
            lineBuffer.Post(line);
        }
        lineBuffer.Complete();
    
        // Wait for uploads to finish
        uploadData.Completion.Wait();
    }
