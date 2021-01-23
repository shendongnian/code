     public static void RunTasks(List<NamedTask> importTaskList)
        {
            List<NamedTask> runningTasks = new List<NamedTask>();
            try
            {
                foreach (NamedTask currentTask in importTaskList)
                {
                    currentTask.Start();
                    runningTasks.Add(currentTask);
                    if (runningTasks.Where(x => x.Status == TaskStatus.Running).Count() >= MaxCountImportThread)
                    {
                        Task.WaitAny(runningTasks.ToArray());
                    }
                }
                Task.WaitAll(runningTasks.ToArray());
            }
            catch (Exception ex)
            {
                Log.Fatal("ERROR!", ex);
            }
        }
