    public class ListItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public String Text { get; set; }
        private bool _isChecked = false;
        public bool IsChecked {
            get { return _isChecked; }
            set {
                _isChecked = value;
                PropertyChanged?.Invoke(this, 
                    new PropertyChangedEventArgs(nameof(IsChecked));
            }
        }
    }
