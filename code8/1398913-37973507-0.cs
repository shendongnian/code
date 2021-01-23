    public ITaskFilter TaskFilter { get; private set };
    public YourViewModel(ITaskFilter taskFilter)
    {
        this.TaskFilter = taskFilter;
    }
