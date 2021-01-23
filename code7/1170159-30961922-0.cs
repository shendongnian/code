    public ObservableCollection<Patient> ComboBoxItemsCollection
        {
            get { return _comboBoxItemsCollection; }
            set
            {
                if (Equals(value, _comboBoxItemsCollection)) return;
                _comboBoxItemsCollection = value;
                OnPropertyChanged();
            }
        }
