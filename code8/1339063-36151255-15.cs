        public string FirstName
        {
            set
            {
                _firtName = value;
                OnPropertyChanged(); //instead of OnPropertyChanged("FirstName") or OnPropertyChanged(nameof(FirstName))
            }
            get{ return _firstName;}
        }
    Please note, that `OnPropertyChanged(() => SomeProperty)` is no more recommended, since we have `nameof` operator in C# 6.
