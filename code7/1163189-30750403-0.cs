        Task[] tasks = new Task[n];
        for (int i = 0; i < files.Length; i += n)
        {
            for (int j = 0; j < n && i + j < files.Length; j++)
            {
                int x = i + j;
                if (files[x] != null)
                    tasks[j] = new Task(() => function(files[x]));
            }
            Task.WaitAll(tasks, Timeout.Infinite); // or less than infinite
        }
