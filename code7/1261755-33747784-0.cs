        var tasks = DownloadFiles();
        var taskArray = tasks.ToArray();
        Task.WaitAll(taskArray);
        Console.WriteLine();
        Console.WriteLine("Download(s) completed.  Parsing sku lookup file.");
        FileInfo[] files = taskArray.Select(t => t.Result).ToArray(); // <-- notice we use taskArray here instead of tasks.
        ParseSkuLookups(files.SingleOrDefault(f => f.Name.ToLowerInvariant().Contains("skulookup")));
    }
