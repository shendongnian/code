    public string value {get;set;}
    public ObservableCollection<string> options {get;set;}
    public bool isComboBox {get;set;}
    public Visibility visibilityTextbox { get { if(isComboBox) { return Visibility.Collapsed; } else { return Visibility.Visible; }} }
    public Visibility visibilityCombobox { get { if(isComboBox) { return Visibility.Visible; } else { return Visibility.Collapsed; }} }
