    private async Task PipelineAsync()
    {
        const int MAX_FILES_TO_BE_QUEUED = 16;
        using (BlockingCollection<FileInfo> queue = new BlockingCollection<FileInfo>(boundedCapacity: MAX_FILES_TO_BE_QUEUED))
        {
            Task producer = Task.Run(async () =>
            {
                try
                {
                    while (true)
                    {
                        DirectoryInfo info = new DirectoryInfo(AssemblyDirectory);
                        HashSet<string> namesOfFilesQeueuedForProcessing = new HashSet<string>();
                        FileInfo[] newFilesToParse = info
                            .GetFiles("*.dat")
                            .Where(f =>
                                (DateTime.Now - f.CreationTime) > TimeSpan.FromSeconds(60) &&
                                !ProcessedFiles.Contains(f.Name))
                            .OrderBy(p => p.CreationTime) // Processing order is not guaranteed.
                            .ToArray();
                        foreach (FileInfo file in newFilesToParse)
                        {
                            // This will block if we reach bounded capacity thereby throttling
                            // the producer (meaning we'll never overflow the handover collection).
                            queue.Add(file);
                            namesOfFilesQeueuedForProcessing.Add(file.Name);
                        }
                        await Task.Delay(TimeSpan.FromSeconds(60)).ConfigureAwait(false);
                    }
                }
                finally
                {
                    // Exception? Cancellation? We'll let the
                    // consumer know that it can wind down.
                    queue.CompleteAdding();
                }
            });
            Task consumer = Task.Run(() =>
            {
                ParallelOptions options = new ParallelOptions {
                    MaxDegreeOfParallelism = Environment.ProcessorCount
                };
                Parallel.ForEach(queue.GetConsumingEnumerable(), options, file => ParseFile(file)); 
            });
            await Task.WhenAll(producer, consumer).ConfigureAwait(false);
        }
    }
