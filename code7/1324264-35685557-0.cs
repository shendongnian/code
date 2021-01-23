    public class ObservableClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        private int _dG1;
        public int DG1
        {
            get { return _dG1; }
            set
            {
                _dG1 = value;
                NotifyPropertyChanged("DG1");
            }
        }
    }
