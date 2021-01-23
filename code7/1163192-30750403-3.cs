        Task[] tasks = new Task[n];
        for (int i = 0; i < files.Length; i += n)
        {
            for (int j = 0; j < n && i + j < files.Length; j++)
            {
                int x = i + j;
                tasks[j] = files[x] != null 
                    ? new Task(() => function(files[x]))
                    : new Task(() => { });
                tasks[j].Start();
            }
            Task.WaitAll(tasks, Timeout.Infinite); // or less than infinite
        }
