    public class MyViewModel : INotifyPropertyChanged
    {
        private string _textInFirstTab;
        public string TextInFirstTab
        {
            get { return _textInFirstTab; }
            set
            {
                _textInFirstTab = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
