    private static async Task<Thing[]> ProcessAllUrls(string[] urls)
    {
        var workBlock = new TransformBlock<string, Thing>(
            async url => await DownloadAndProcessUrl(url),
            new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 20 }
            );
     
        var outputBlock = new BufferBlock<Thing>();
     
        using (workBlock.LinkTo(outputBlock, new DataflowLinkOptions { PropagateCompletion = true }))
        {
     
            foreach (var url in urls)
            {
                workBlock.Post(url);
            }
     
            // signal no more input going into workblock
            workBlock.Complete();
     
            // wait for workblock to pump all data into outputblock
            await workBlock.Completion;
     
            IList<Thing> finalResult = null;
            bool result = outputBlock.TryReceiveAll(out finalResult);
            return finalResult.ToArray();
        }
    }
