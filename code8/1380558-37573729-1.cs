     public MainWindow()
        {
            Items = new List<Device>();
            Items.Add(new Device() { Name = "Device1",DeviceState = 1 });
            Items.Add(new Device() { Name = "Device2", DeviceState = 2 });
            Items.Add(new Device() { Name = "Device3", DeviceState = 3 });
            Items.Add(new Device() { Name = "Device4", DeviceState = 4 });
            Items.Add(new Device() { Name = "Device5", DeviceState = 5 });
            InitializeComponent();
            
        }
        public List<Device> Items { get; set; }
        private string _selectedParam = "1";
        public string SelectedParam
        {
            get { return _selectedParam; }
            set
            {
                _selectedParam = value; 
                UpdateProperty("SelectedParam");                
            }
        }
