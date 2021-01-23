    // Attach EventHandler
    ConnectionHelper.PropertyChanged += OnConnectionHelperPropertyChanged;
    
    ...
    
    // When property gets changed, raise the PropertyChanged 
    // event of the ViewModel copy of the property
    OnConnectionHelperPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "Something") //your ConnectionHelper property name
            RaisePropertyChanged("Ouput");
    }
