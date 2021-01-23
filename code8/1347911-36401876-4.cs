    public class StepController : INotifyPropertyChanged
    {
        private bool _stepEnabled;
        private bool? _wasSuccessful;
        public StepController()
        {
            Clear();
        }
        public bool StepEnabled
        {
            get { return _stepEnabled; }
            set
            {
                if (value == _stepEnabled) return;
                _stepEnabled = value;
                OnPropertyChanged();
            }
        }
        public bool? WasSuccessful
        {
            get { return _wasSuccessful; }
            set
            {
                if (value == _wasSuccessful) return;
                _wasSuccessful = value;
                OnPropertyChanged();
            }
        }
        public void Clear()
        {
            StepEnabled = false;
            WasSuccessful = null;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
