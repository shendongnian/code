    public class BookViewModel : INotifyPropertyChanged
    {
        string _Title;
        public string Title
        {
            get { return _Title; }
            set
            {
                CheckAndNotifyState(_Title, value, "Title");
                _Title = value;
            }
        }
    
        string _AuthorName;
        public string AuthorName
        {
            get { return _AuthorName; }
            set
            {
                CheckAndNotifyState(_AuthorName, value, "AuthorName");
                _AuthorName = value;
            }
        }
    
        State _State;
        public State State
        {
            get { return _State; }
            set
            {
                CheckAndNotifyState(_State, value, "State");
                _State = value;
            }
        }
    
    
        private void CheckAndNotifyState(object oldValue, object newValue, string propertyName)
        {
            if (oldValue != newValue)
            {
                State = State.Edit;
                NotifyPropertyChanged(propertyName);
            }
        }
    
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
    
    public enum State
    {
        Default,
        Edit,
        Saved
    }
