    public static void Main(string[] args)
    {
        Dictionary<string, List<string>> filesToProcess = new Dictionary<string, List<string>>();
        // Loop over the 2 arrays and creates a directory that contains the host as the key, and then all the filenames.
        group_file_paths.Each((host, hostIndex) =>
        {
            if (filesToProcess.ContainsKey(host))       
            { filesToProcess[host].Add(group_file_host_name[hostIndex]); }
            else
            {
                filesToProcess.Add(host, new List<string>());
                filesToProcess[host].Add(group_file_host_name[hostIndex]);
            }
        });
        var tasks = new List<Task>();
        foreach (var kvp in filesToProcess)
        {
            tasks.Add(Task.Factory.StartNew(() => 
            {
                foreach (var file in kvp.Value)
                {
                    process_file(kvp.Key, file);
                }
            }));
        }
        var handleTaskCompletionTask = Task.WhenAll(tasks);
        handleTaskCompletionTask.Wait();
    }
