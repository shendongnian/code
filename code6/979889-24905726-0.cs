    public ObservableCollection<String> Items 
    {
        get { return items; }
        set {
           if( items==value )
               return;
            items = value;
            RaisePropertyChanged("Items");
        }
    }
    public String SelectedItem {...}
