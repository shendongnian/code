        public void IncreasePriority(string taskName)
        {
            try
            {
                Lock.EnterUpgradeableReadLock();
                var taskQuery = from t in DeveloperTasks
                                where t.Name == taskName select t;
                if (taskQuery.Count<DeveloperTask>() > 0)
                { DeveloperTask task = taskQuery.First<DeveloperTask>();
                    Lock.EnterWriteLock(); task.Priority++;
                    Console.WriteLine($"Task {task.Name}" + $" priority was increased to {task.Priority}" + " for developer"); Lock.ExitWriteLock();
                }
            }
            finally
            {
                Lock.ExitUpgradeableReadLock();
            }
        }
