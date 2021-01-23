    public type Customers
    {
        get{return _Customers} 
        set{_SelectedCustomer = value; 
            NotifyPropertyChanged("Customers");}
    }
    public type SelectedCustomer
    {
        get{return _SelectedCustomer;} 
        set{_SelectedCustomer = value;
            NotifyPropertyChanged("SelectedCustomer")}
    }
