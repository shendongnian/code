    public class ViewModel : INotifyPropertyChanged
    {
        public int ThreadCount { get; set; }
        public int ProxyTimeout { get; set; }
        private string _logBox;
        public string LogBox
        {
            get { return _logBox; }
            set
            {
                _logBox = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
