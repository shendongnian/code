    private ObservableCollection<Plan> _items = new ObservableCollection<Plan>();
    
    public Window()
    {
        InitializeComponent();
        Plan.ItemsSource = _items;
    }
    
    private void Einfügen_Click(object sender, RoutedEventArgs e)
    {
        _items.Add(new Plan(LinieZ, Convert.ToString(Kurs.SelectedItem), AbfZ, VonZ, NachZ, AnkZ, "---"));
    }
