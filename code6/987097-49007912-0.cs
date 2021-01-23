    //probably in my constructor (or use dependency injection)
    this.cache = new CachingService()
    
    public List<MyTasks> GetTasks() 
    {
        return cache.GetOrAdd<List<MyTasks>>("get-tasks", () = > {
            //go and get the tasks here.
        });
    }
