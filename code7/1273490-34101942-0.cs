    try
    {
        var directoryPath = _Configurations.Descendants().SingleOrDefault(Pr => Pr.Name == "DirectoryPath").Value;
        var filePaths = CreateBlockingCollection(directoryPath);
        //Start the same #tasks as the #cores (Assuming that #files > #cores)
        int taskCount = System.Environment.ProcessorCount;
        for (int i = 0; i < taskCount; i++)
        {
            Task.Factory.StartNew(
                    () =>
                    {
                        string fileName;
                        while (!filePaths.IsCompleted)
                        {
                             if (!filePaths.TryTake(out fileName)) continue;
                             this.ProcessFile(fileName);
                        }
                    });
         }
    }
