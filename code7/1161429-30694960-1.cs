    private Queue<Delegate> TaskQueue;
    ...
    public void AddTask(Delegate task)
    {
        this.TaskQueue.Enqueue(task);
    }
