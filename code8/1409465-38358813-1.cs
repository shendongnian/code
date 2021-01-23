    public partial class Form1 : Form
    {
        
        
        int k = 1;
        string number_of_bytes;
        byte checksum;
        byte[] buffer = new byte[11];
        byte[] buffer_old = new byte[11];
        
        public Form1()
        {
            InitializeComponent();
            configure_button.Enabled = false;
            start_button.Enabled = false;
            foreach (string s in SerialPort.GetPortNames())
            {
                serial_port_name.Items.Add(s);
            }
            serial_port_name.Text = "Select port";
            for (int i = 4800; i <= 38400; i = i * 2)
            {
                baud_rate.Items.Add(i);
            }
            for (int i = 57600; i <= 921600; i = i * 2)
            {
                baud_rate.Items.Add(i);
            }
            serial_port_name.DropDownStyle = ComboBoxStyle.DropDownList;
            baud_rate.SelectedIndex = 3;
            baud_rate.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void serial_port_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serial_port_name.Text != "Select port")
            {
                configure_button.Enabled = true;
            }
        }
        private void configure_button_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = serial_port_name.Text;
            serialPort1.BaudRate = Int32.Parse(baud_rate.Text);
            serialPort1.DataBits = 8;
            serialPort1.StopBits = StopBits.One;
            //serialPort1.Handshake = Handshake.None;
            serialPort1.ReceivedBytesThreshold = 44;
            serialPort1.ReadBufferSize = 8192;
            MessageBox.Show("Communication is set on " + serialPort1.PortName + " with baud rate: " + serialPort1.BaudRate);
            start_button.Enabled = true;
        }
        private void start_button_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                
                serialPort1.Close();
                start_button.Text = "START";
                read_button.Enabled = false;
                //read_write.Enabled = false;
                comport_status.Text = "DISCONNECTED";
            }
            else
            {
                serialPort1.Open();
                start_button.Text = "STOP";
                read_button.Enabled = true;
                //read_write.Enabled = true;
                comport_status.Text = "CONNECTED";
            }
        }
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        private void read_button_Click(object sender, EventArgs e)
        {
            bytes_to_read.Text = serialPort1.BytesToRead.ToString();
            read_data.Text = serialPort1.ReadExisting().ToString();
            read_data.Text += k.ToString() + "   ";
            if (buffer_old[0] == 4)
            {
                serialPort1.ReadByte();
            }
            serialPort1.Read(buffer, 0, 11);
            for (int j = 0; j < 11; j++)
            {
                read_data.Text += buffer[j].ToString() + "  ";
            }
            read_data.Text += "\n";
            k++;
            buffer_old = buffer;
        }
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            
            serialPort1 = (SerialPort)sender;
            number_of_bytes = serialPort1.BytesToRead.ToString();
            if (buffer_old[0] == 4)
            {
                serialPort1.ReadByte();
            }
            serialPort1.Read(buffer, 0, 11);
            buffer_old = buffer;
            this.Invoke(new EventHandler(displaytext));
            Thread.Sleep(20);
        }
        private void displaytext(object sender, EventArgs e)
        {
            checksum = 0;
            bytes_to_read.Text = number_of_bytes;
            read_data.Text += k.ToString() + "\t";
            for (int j = 0; j < 11; j++)
            {
                read_data.Text += buffer[j].ToString() + "  ";
                checksum += buffer[j]; 
            }
            checksum -= buffer[10];
            read_data.Text += "  \t" + checksum.ToString();
            read_data.Text += "\n";
            k++;
        }
    }
}
