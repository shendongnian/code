    // View
    <ComboBox SelectedItem="{Binding First}" ItemsSource="{Binding Selectables}" IsSynchronizedWithCurrentItem="True" />
    <ComboBox SelectedItem="{Binding Second}" ItemsSource="{Binding Selectables2}" IsSynchronizedWithCurrentItem="True" Grid.Column="1" />
    
    // Model
    
    public ObservableCollection<string> Selectables { get; set; }
    public ObservableCollection<string> Selectables2 { get; set; }
    private string _first;
    private string _second;
    public string First {
        get {
            return _first;
        }
        set {
            if(_first == value) {
                return;
            }
            _first = value;
            Second = value;
            OnPropertyChanged("First");
        }
    }
    public string Second {
        get {
            return _second;
        }
        set {
            if(_second == value) {
                return;
            }
            _second = value;
            First = value;
            OnPropertyChanged("Second");
        }
    }
