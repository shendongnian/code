    public void ProcessFiles(string inputFilePath)
    {
        DirecotryInfo dir = new DirectoryInfo(inputFilePath);
        if (!dir.Exsists)
        {
            ReportProblem(...);
            return;
        }
        
        var filesToProcess = dir.EnumerateFiles()
            .Where(fileInfo => IsFileNameAcceptable(fileInfo.Name);
        var runningTasks = filesToProcess
            .Select(fileToProcess => Task.Run( () => ProcessSingleFile(file.Name, log, f))
            .ToArray();
        // note: linq uses deferred execution.
        // ToArray is used to make sure the tasks are really started
        // while the tasks are running you can do other things
        // after a while wait for the tasks to finish:
        runningTasks.WaitAll();
    }
    private bool IsFileNameAcceptable(string fileName)
    {
       return !(fileName.ToUpper().Contains("ENCODING") || fileName.Contains("HEADERS"));
       // or did you mean:
       var upperFileName = fileName.ToUpper();
       return !upperFileName.Contains("ENCODING")
           && !upperFileNmae.Contains("HEADERS");
    }
