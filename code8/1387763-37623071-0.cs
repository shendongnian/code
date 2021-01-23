    public string meCurrentValue
    {
    get { return _mecurrentvalue; }
    set { 
    _mecurrentvalue = value;
    updateSuggestionsList();
    NotifyPropertyChanged("meCurrentValue");
    NotifyPropertyChanged("meFilteredListOfSuggestions"); // notify that the list was updated
    ComboBox.Open(); // use to open the combobox list
    }
    
    public List<string> meFilteredListOfSuggestions
    {
    get{return SuggestionsList.Select( e => e.text.StartsWith(_mecurrentvalue));}
    }
