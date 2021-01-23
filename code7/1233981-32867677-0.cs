    class TaskViewModel : BindableBase
    {
        private readonly Task _task;
        public TaskViewModel(Task task)
        {
            _task = task;
        
            Subject = _task.Subject;
        }
        string _subject = null;
        public String Subject
        {
            get { return _subject; }
            set
            {
                _task.Subject = value;
               SetProperty(ref _subject, value)
            }
        }
    }
