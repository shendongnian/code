    private bool _taskRunning;
    public bool TaskRunning
    {
      get
        {
            if(someTask!= null && someTask.Status == TaskStatus.Running)
               _taskRunning=true;
           return _taskRunning;
        }
      set
        {
           _taskRunning=value;
           RaisePropertyChanged("TaskRunning");
        }
    }
    
