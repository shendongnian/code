    var tasks = new Task[8];
    var names = fileNames.ToArray();
    for (int i = 0; i < tasks.Length; i++)
    {
        int index = i;
        tasks[i] = Task.Run(() =>
        {
            for (int current = index; current < names.Length; current += 8)
            {
                // execute the workload
                string str = names[current];
                foreach (var file in Directory.GetFiles(folderToCheckForFileName, str, SearchOption.AllDirectories))
                {
                    string combinedPath = Path.Combine(newTargetDirectory, Path.GetFileName(file));
                    if (!File.Exists(combinedPath))
                    {
                        File.Copy(file, combinedPath);
                    }
                }
            }
        });
    }
    Task.WaitAll(tasks);
