    private async void OnTimedEvent(object source, ElapsedEventArgs e)
    {
      DirectoryInfo info = new DirectoryInfo(AssemblyDirectory);
      FileInfo[] allSrcFiles = info.GetFiles("*.dat").OrderBy(p => p.CreationTime).ToArray();
      var validSrcFiles = allSrcFiles.Where(p => (DateTime.Now - p.CreationTime) > TimeSpan.FromSeconds(60));
      var newFilesToParse = validSrcFiles.Where(f => !ProcessedFiles.Contains(f.Name));
      if (newFilesToParse.Any()) Console.WriteLine("Adding " + newFilesToParse.Count() + " files to the Queue");
      var blockOptions = new ExecutionDataflowBlockOptions
      {
        MaxDegreeOfParallelism = coresCount,
      };
      var block = new ActionBlock<FileInfo>(ParseFile, blockOptions);
      var filesToParseCount = 0;
      foreach (var file in newFilesToParse)
      {
        block.Post(file);
        ProcessedFiles.Add(file.Name);
        ++filesToParseCount;
      }
      Console.WriteLine("There are " + filesToParseCount + " files in queue. Processing...");
      block.Complete();
      await block.Completion;
      Console.WriteLine("Finished processing Files in the Queue. Waiting for new files...");
    }
