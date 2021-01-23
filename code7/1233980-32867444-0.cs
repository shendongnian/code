    class TaskViewModel : BindableBase
    {
        LoadData()
        {
           Subject = GetSubject(); // Relies on model
        }
        string _subject = null;
        public String Subject
        {
            get{ return _subject; }
            set
            {
                _subject = value;
               SetProperty(ref _task.Subject, value)
            }
        }
    }
