    public class CitysList:INotifyPropertyChanged
        {
            
            private ObservableCollection<City> _citylist  ;
            public ObservableCollection<City> CityList
            {
                get
                {
                    return _citylist;
                }
                set
                {
                    if (_citylist == value)
                    {
                        return;
                    }
                    _citylist = value;
                    OnPropertyChanged();
                }
            }            
            public event PropertyChangedEventHandler PropertyChanged;            
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
