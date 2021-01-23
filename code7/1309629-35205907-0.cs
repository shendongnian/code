    public partial class MainForm : Form
    {
        SerialPort _port;
    
        public MainForm()
        {
            InitializeComponent();
        }
    
        private void MainForm_Load(object sender, EventArgs e)
        {
            var ports = SerialPort.GetPortNames();
            cmbSerialPorts.DataSource = ports;
        }
    
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "Connect")
            {
                btnConnect.Text = "Disconnect";
    
                if (cmbSerialPorts.SelectedIndex > -1)
                {
                    MessageBox.Show(String.Format("You selected port '{0}'", cmbSerialPorts.SelectedItem));
                    Connect(cmbSerialPorts.SelectedItem.ToString());
                }
                else
                {
                    MessageBox.Show("Please select a port first");
                }
            }
            else
            {
                btnConnect.Text = "Connect";
                _port.Close();
            }
    
        }
    
        private void Connect(string portName)
        {
            _port = new SerialPort(portName);
            if (!_port.IsOpen)
            {
                _port.BaudRate = 921600;
                _port.DataBits = 8;
                _port.StopBits = StopBits.One;
                _port.Parity = Parity.None;
                _port.Handshake = Handshake.None;
                _port.Open();
            }
        }
    }
