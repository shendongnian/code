     public MainWindow()
        {
            InitializeComponent();
            Items = new[] {"ABC", "DEF"};
            this.DataContext = this;
        }
        public string[] Items
        { get; set; }
