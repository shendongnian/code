    if (value!=_myprivateproperty)
    {
        NotifyPropertyChanging("MyPublicPropertyName");
        _myprivateproperty = value;
        NotifyPropertyChanged("MyPublicPropertyName");
    }
