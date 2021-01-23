        public void AddTask(DeveloperTask newTask)
        {
            try
            {
                Lock.EnterWriteLock();        
                // if we already have this task (unique by name)        
                // then just accept the add as sometimes people        
                // give you the same task more than once :)        
                var taskQuery = from t in DeveloperTasks
                                where t == newTask
                                select t;
                if (taskQuery.Count<DeveloperTask>() == 0)
                {
                    Console.WriteLine($"Task {newTask.Name} was added to developer");
                    DeveloperTasks.Add(newTask);
                }
            }
            finally
            {
                Lock.ExitWriteLock();
            }
        }
