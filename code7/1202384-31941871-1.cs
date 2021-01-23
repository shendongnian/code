    // View
    
    <ComboBox SelectedItem="{Binding First}" ItemsSource="{Binding Selectables}" IsSynchronizedWithCurrentItem="True" />
    <ComboBox SelectedItem="{Binding Second}" ItemsSource="{Binding Selectables}" IsSynchronizedWithCurrentItem="True" Grid.Column="1" />
    // Model
    
    public ObservableCollection<string> Selectables { get; set; }
    private string _first;
    private string _second;
    public string First {
        get {
            return _first;
        }
        set {
            _first = value;
            OnPropertyChanged("First");
        }
    }
    public string Second {
        get {
            return _second;
        }
        set {
            _second = value;
            OnPropertyChanged("Second");
        }
    }
