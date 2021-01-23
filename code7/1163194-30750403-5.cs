        List<Task> tasks = new List<Task>(n);
        for (int i = 0; i < files.Length; i += n)
        {
            for (int j = 0; j < n; j++)
            {
                int x = i + j;
                if (x < files.Length && files[x] != null)
                {
                    Task t = new Task(() => function(files[x]));
                    t.Start();
                    tasks.Add(t);
                }
            }
            if (tasks.Count > 0)
            {
                Task.WaitAll(tasks.ToArray(), Timeout.Infinite); // or less than infinite
                tasks.Clear();
            }
        }
