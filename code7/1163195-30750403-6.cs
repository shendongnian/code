        List<Task> tasks = new List<Task>(taskCount);
        for (int filesIdx = 0; filesIdx < files.Length; filesIdx += taskCount)
        {
            for (int tasksIdx = 0; tasksIdx < taskCount; tasksIdx++)
            {
                int index = filesIdx + tasksIdx;
                if (index < files.Length && files[index] != null)
                {
                    Task task = new Task(() => function(files[index]));
                    task.Start();
                    tasks.Add(task);
                }
            }
            if (tasks.Count > 0)
            {
                Task.WaitAll(tasks.ToArray(), Timeout.Infinite); // or less than infinite
                tasks.Clear();
            }
        }
