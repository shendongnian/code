    [Flags]
    public enum TaskOptions 
    {
        Print    = 1,
        Save     = 2,
        SendMail = 4
    }
	// In the clase where print(), save() and sendmail() are declared
    private readonly Dictionary<TaskOptions, Action> _tasks;
    public Ctor()
    {
        _tasks = new Dictionary<TaskOptions, Action>
            {
                { TaskOptions.Print, this.print },
                { TaskOptions.Save, this.save },
                { TaskOptions.SendMail, this.sendmail }
            };
    }
    public void Do(TaskOptions tasksToRun)
    {
        foreach (var action in from taskOption in Enum.GetValues(typeof(TaskOptions)).Cast<TaskOptions>()
                               where tasksToRun.HasFlag(taskOption)
                               orderby taskOption // only to specify it in the declared order
                               select this._tasks[taskOption])
        {
            action();
        }
    }
	
