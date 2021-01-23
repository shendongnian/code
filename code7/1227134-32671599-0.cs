       public List<Item> List { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            List = new List<Item>();
            List.Add(new Item() { id = 1, name = "stack" });
            List.Add(new Item() { id = 2, name = "overflow" });
            DataContext = this; //This is the only place where you should set datacontext
        }
   
       <ComboBox x:Name="comboBox" HorizontalAlignment="Left" Margin="22,14,0,0" 
        VerticalAlignment="Top" Width="147" ItemsSource="{Binding List}" SelectedIndex=0 >
