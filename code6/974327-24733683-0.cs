    public partial class Communication : UserControl
    {
        public SerialPort comPort = new SerialPort();
        public ObservableCollection<string> Ports {get;set;}
    
        public Communication()
        {
            InitializeComponent(); 
        }
    
        public void GetPortNames()
        {
            int num;
            this.Ports= new ObservableCollection<string>();
            string[] port_Names = SerialPort.GetPortNames().OrderBy(a => a.Length > 3 && int.TryParse(a.Substring(3), out num) ? num : 0).ToArray();
    
            foreach (string port in port_Names)
                this.Ports.Add(port);
            this.DataContext=this;
            ComboBoxPorts.ItemsSource = this.Ports;
            ComboBoxPorts.SelectedItem = this.Ports.FirstOrDefault(); // object to show on comboBox
        }
    }
