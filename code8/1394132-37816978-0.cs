            public MainWindow()
        {
            ObservableCollection<string> Stuff = new ObservableCollection<string>();
            Stuff.Add("Stuff1");
            Stuff.Add("Stuff2");
            Stuff.Add("Stuff3");
            Stuff.Add("Stuff4");
            InitializeComponent();
            NamesComboBox.ItemsSource = Stuff;//here you set the itemsSource
            NamesComboBox.SelectionChanged += NamesComboBoxOnSelectionChanged;// or you can create this on xaml like SelectionChanged="NamesComboBoxOnSelectionChanged"
        }
