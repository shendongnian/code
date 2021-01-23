    private readonly CacheManager cacheManager = new CacheManager(); 
              // or injected via ctor
    
    public IEnumerable<Task> GetTasks()
    {
        return this.cacheManager.Get("Tasks", ctx => this.taskRepository.GetAll());
    }
    
    public void AddTask(Task task)
    {
        this.taskRepository.Create(task);
        /// other code
        
        // we need to tell the cache that it should get fresh collectiion
        this.cacheManager.Signal("Tasks"); 
    }
