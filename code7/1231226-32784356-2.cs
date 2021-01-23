    public class DataTableItem : INotifyPropertyChanged
    {
        private string _Data;
        public string Data
        {
            get { return _Data; }
            set
            {
                _Data = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Data"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
