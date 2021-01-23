    public ViewModel : INotifyPropertyChanged
    {
    
            private ObservableCollection<Level> mLevels;
    
            public ObservableCollection<Level> Levels
            {
                get
                {
                    if (mLevels == null)
                    {
                        mLevels = new ObservableCollection<Level>();
                    }
                    return mLevels;
                }
                set
                {
                    mLevels = value;
                    OnPropertyChanged("Levels");
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    }
