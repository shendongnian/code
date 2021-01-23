            public bool IsTaskDone(string taskName)
        {
            try
            {
                Lock.EnterReadLock();
                var taskQuery = from t in DeveloperTasks
                                where t.Name == taskName select t;
                if (taskQuery.Count<DeveloperTask>() > 0)
                {
                    DeveloperTask task = taskQuery.First<DeveloperTask>();
                    Console.WriteLine($"Task {task.Name} status was reported.");
                    return task.Status; } }
            finally
            {
                Lock.ExitReadLock();
            }
            return false;
        }
