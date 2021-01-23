    internal class Test : INotifyPropertyChanged
        {
            private ObservableCollection<string> _sharedValues;
    
            public Test()
            {
                SharedValues = new ObservableCollection<string>();
            }        
    
            public ObservableCollection<string> SharedValues
            {
                get { return _sharedValues; }
                set
                {
                    _sharedValues = value;
                    OnPropertyChanged();
                }
            }
    
            #region NotifyPropertyChanged
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
    
            #endregion
        }
