    public class TaskModel : INotifyPropertyChanged
    {
        private bool _isFocused;
        public bool IsFocused
        {
            get { return _isFocused; }
            set
            {
                _isFocused = value;
                RaisePropertyChanged();
            }
        }
