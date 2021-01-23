    [Event(2, Level = EventLevel.Error)]
    public void TaskCreate(long TaskId) 
    { 
        if (IsEnabled()) 
           WriteEvent(2, TaskId); 
    }
