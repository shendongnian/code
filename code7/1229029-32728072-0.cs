    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            TBBind = "test";
        }
        private string _tBBind;
        public string TBBind
        {
            get { return _tBBind; }
            set
            {
                if (value != _tBBind)
                {
                    _tBBind = value;
                    OnPropertyChanged("TBBind");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            MessageBox.Show("OnPropertyChanged triggered");
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
