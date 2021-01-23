    private myPErson _MyPerson;
        public myPErson MyPerson
        {
            get { return _MyPerson; }
            set
            {
                if (_MyPerson != null)
                    _MyPerson.PropertyChanged -= MyPersonOnPropertyChanged;
    
                SetProperty(ref _MyPerson, value);
    
    
                if (_MyPerson != null)
                    _MyPerson.PropertyChanged += MyPersonOnPropertyChanged;
            }
        }
    
        private void MyPersonOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            updateCommand.RaiseCanExecuteChanged();
        }
