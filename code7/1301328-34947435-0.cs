    public class MyCollection : ObservableCollection<ITimeLineDataItem>
    {
    }
    public class ITimeLineDataItem: INotifyPropertyChanged
    {
        private string _aProperty;
        public string  AProperty
        {
            get { return _aProperty; }
            set
            {
                if (_aProperty!= value)
                {
                    _aProperty= value;
                    OnPropertyChanged("AProperty");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
