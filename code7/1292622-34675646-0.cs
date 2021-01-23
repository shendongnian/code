    static void RunProgram(CancellationToken ct)
    {
        try
        {
            foreach (var dir in _directoriesToProcess)
            {
                var newTask = CreateNewTask(dir, ct);
                _tasks.Add(newTask);
            }
            //change your while so it does not execute all the time
            while (_tasks.Count > 0)
            {
                lock (_collectionLock)
                {
                    var tsk = _tasks.FirstOrDefault();
                            if (tsk != null)
                            {
                                if (tsk.Status <= TaskStatus.Running)
                                    await tsk;
                                _tasks.Remove(tsk);
                            }
                }
            }
            OutputFiles();
            StopAndCleanup();
        }
        catch (Exception ex)
        {
            Log(LogColor.Red, "Error: " + ex.Message, false);
            _cts.Cancel();
        }
    }
    static Task CreateNewTask(string Path, CancellationToken ct)
    {
        return Task.Factory.StartNew(() => GetDirectoryFiles(Path, ct), ct);
    }
    //always use Task (or Task<T>) as return so you can await the process
    static async Task GetDirectoryFiles(string Path, CancellationToken ct)
    {
        if (!ct.IsCancellationRequested)
        {
            //Insert Magic
            await Task.Run(() => {
                List<string> subDirs = new List<string>();
                int currentFileCount = 0;
                try
                {
                    currentFileCount = Directory.GetFiles(Path, _fileExtension).Count();
                    subDirs = Directory.GetDirectories(Path).ToList();
                    lock (_objLock)
                    {
                        _overallFileCount += currentFileCount;
                        Log(LogColor.White, "- Current path: " + Path);
                        Log(LogColor.Yellow, "--  Sub directory count: " + subDirs.Count);
                        Log(LogColor.Yellow, "--  File extension: " + _fileExtension);
                        Log(LogColor.Yellow, "--  Current count: " + currentFileCount);
                        Log(LogColor.Red, "--  Running total: " + _overallFileCount);
                        _csvBuilder.Add(string.Format("{0},{1},{2},{3}", Path, subDirs.Count, _fileExtension, currentFileCount));
                        Console.Clear();
                        Log(LogColor.White, "Running file count: " + _overallFileCount, false, true);
                    }
                    foreach (var dir in subDirs)
                    {
                        lock (_collectionLock)
                        {
                            var newTask = CreateNewTask(dir, ct);
                            _tasks.Add(newTask);
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                Log(LogColor.Red, "Error: " + ex.Message, false);
                _cts.Cancel();
            }
        }
    } 
