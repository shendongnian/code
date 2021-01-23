            private ComboBox _selectedSubject;
            public ComboBox SelectedSubject
            {
                get { return _selectedSubject; }
    
                set
                {
                    _selectedSubject = value;
                    RaisePropertyChanged("SelectedSubject");
                }
            }
