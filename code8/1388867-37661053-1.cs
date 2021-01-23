    private string _firstLastName;
    public string FirstLastName {
        get { return _firstLastName; }
        set {
            if(_firstLastName != value) {
                _firstLastName = value;
                SetPropertyChanged();
            }
        }
    }
    private string _firstName;
    public string FirstName {
        get { return _firstName; }
        set {
            if(_firstName != value) {
                _firstName = value;
                SetPropertyChanged();
                SetPropertyChanged("FirstLastName"); //Also send alert that FirstLastName changed
            }
        }
    }
