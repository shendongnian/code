    class TaskViewModel : BindableBase
    {
        private readonly Task _task;
        private string _subject;
        public TaskViewModel(Task task)
        {
            _task = task;
        
            Subject = _task.Subject;
        }
        public string Subject
        {
            get { return _subject; }
            set
            {
                _task.Subject = value;
               SetProperty(ref _subject, value)
            }
        }
    }
