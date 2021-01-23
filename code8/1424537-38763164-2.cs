            private string _someStringProperty;
            public string SomeStringProperty
            {
                get { return _someStringProperty; }
                set
                {
                    _someStringProperty = value;
                    OnPropertyChanged();
                }
            }
