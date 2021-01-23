        class Test : INotifyPropertyChanged
    {
    public string _txt{get;set;}
    private Visibility _placeholderVisbile { get; set; }
            public Visibility PlaceholderVisible
            {
                get { return _placeholderVisbile; }
                set { _placeholderVisbile = value; OnPropertyChanged("PlaceholderVisible"); }
            }
    private void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            public event PropertyChangedEventHandler PropertyChanged;
    }
