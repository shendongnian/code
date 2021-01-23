    public class TaskManager : ITaskManager
    {
        public IRepository<BackgroundTask> TaskRepository { get; set; }
        public async Task<int> CreateTask(TaskType type, 
                                          byte[] data = null, 
                                          object config = null)
        {
            var task = new BackgroundTask
            {
                Type = type,
                Status = BackgroundTaskStatus.New,
                Config = config?.SerializeToXml(),
                Created = DateTime.Now,
                Data = data
            };
    
            TaskRepository.Add(task);
            TaskRepository.SaveChanges();
    
            return task.Id;
        }
    
        public ask Run(int id, bool removeOnComplete = true)
        {
            var task = TaskRepository.GetById(id);
            return Run(task, removeOnComplete);
        }
    
        public Task Run(TaskType type, bool removeOnComplete = true)
        {
            var tasksToRun = TaskRepository.Get(t => t.Type == type);
            return tasksToRun.ForEachAsync(t => Run(t, removeOnComplete));
        }
    
        public Task Run(BackgroundTask task, bool removeOnComplete = true)
        {
            switch (task.Type)
            {
                case TaskType.SpreadsheetImport:
                    return new SpreadsheetImportTaskRunner().Run(task);
                    break;                    
                }                  
            }
        }
    }
