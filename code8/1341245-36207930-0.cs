    namespace Barcode_Scanner
    {
        public partial class Form1 : Form
        {
            SerialPort sp;
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                string[] ports = SerialPort.GetPortNames();
                comboBox1.DataSource = ports;
            }
            private void btn_getComData_Click(object sender, EventArgs e)
            {
                try
                {
                    if (!sp.IsOpen)
                    {
                        button1_Click(null, EventArgs.Empty);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem with the Serial Port: " + ex.Message, "Error!");
                }
            }
            void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
            {
                string data = sp.ReadExisting();
                txt_comData.Appendtext(data);
            }
            private void button1_Click(object sender, EventArgs e)
            {
                // Makes sure serial port is open before trying to write
                string portname = comboBox1.SelectedItem.ToString();
                sp = new SerialPort(portname, 9600, Parity.None, 8, StopBits.One);
                sp.Handshake = Handshake.None;
                sp.Open();
                sp.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
            }
            private void button2_Click(object sender, EventArgs e)
            {
                sp.Close();
            }
        }
    }
