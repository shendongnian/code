    public class MyViewModel : INotifyPropertyChanged 
    {
        bool _isChecked;
        public bool IsChecked
        {
            get { return _isChecked; }
            set {
                _isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
