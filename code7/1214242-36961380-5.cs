    public class DeviceTimer
    {
      readonly Action _Task;
      readonly List<TaskWrapper> _Tasks = new List<TaskWrapper>();
      readonly TimeSpan _interval;
      public bool IsRecurring { get; }
      public bool IsRunning => _Tasks.Any(t => t.IsRunning);
      public DeviceTimer(Action task, TimeSpan interval, 
        bool isRecurring = false, bool start = false)
      {
        _Task = task;
        _interval = interval;
        IsRecurring = isRecurring;
        if (start)
          Start();
      }
      public void Restart()
      {
        Stop();
        Start();
      }
      public void Start()
      {
        if (IsRunning)
          // Already Running
          return;
        var wrapper = new TaskWrapper(_Task, IsRecurring, true);
        _Tasks.Add(wrapper);
        Device.StartTimer(_interval, wrapper.RunTask);
      }
      public void Stop()
      {
        foreach (var task in _Tasks)
          task.IsRunning = false;
        _Tasks.Clear();
      }
      class TaskWrapper
      {
        public bool IsRunning { get; set; }
        bool _IsRecurring;
        Action _Task;
        public TaskWrapper(Action task, bool isRecurring, bool isRunning)
        {
          _Task = task;
          _IsRecurring = isRecurring;
          IsRunning = isRunning;
        }
        public bool RunTask()
        {
          if (IsRunning)
          {
            _Task();
            if (_IsRecurring)
              return true;
          }
          // No longer need to recur. Stop
          return IsRunning = false;
        }
      }         
    }           
