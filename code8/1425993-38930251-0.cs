    public partial class Form1 : Form
    {
        ManagementEventWatcher watcher;
        // Not all arduinos have 'Arduino' in their serialport driver 'Description', So check for a Com port Number.
        private static string MustHavePort = "COM3"; //Port to check for.
        public Form1()
        {
            InitializeComponent();
            watcher = new ManagementEventWatcher("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2 or EventType = 3");
            watcher.EventArrived += new EventArrivedEventHandler(USBChangedEvent);
            watcher.Start();
        }
        public void USBChangedEvent(object sender, EventArrivedEventArgs e)
        {
            (sender as ManagementEventWatcher).Stop();
            this.Invoke((MethodInvoker)delegate
            {
                ManagementObjectSearcher deviceList = new ManagementObjectSearcher("Select Name, Description, DeviceID from Win32_SerialPort");
                
                // List to store available USB serial devices plugged in. (Arduino(s)/Cell phone(s)).
                List<String> ComPortList = new List <String>();   
                
                listBox1.Items.Clear();
                textBox1.Text = "";
                // Any results? There should be!
                if (deviceList != null)
                {
                    // Enumerate the devices
                    foreach (ManagementObject device in deviceList.Get())
                    {
                        string SerialPortNumber = device["DeviceID"].ToString();
                        string serialName = device["Name"].ToString();
                        string SerialDescription = device["Description"].ToString();
                        ComPortList.Add(SerialPortNumber);
                        listBox1.Items.Add(SerialPortNumber);
                        listBox1.Items.Add(serialName);
                        listBox1.Items.Add(SerialDescription);
                    }
                }
                else
                {
                    listBox1.Items.Add("NO SerialPorts AVAILABLE!");
                    // Inform the user about the disconnection of the arduino ON PORT 3 etc...
                    SendAlarm();
                }
                if (!ComPortList.Contains(MustHavePort))
                {
                    // Inform the user about the disconnection of the arduino ON PORT 3 etc...
                    SendAlarm();
                }
            });
            (sender as ManagementEventWatcher).Start();
        }
        private void SendAlarm()
        {
            textBox1.Text = "Alarm..." + MustHavePort + "Port Missing...";
            MessageBox.Show("Error " + MustHavePort + " Port Missing!!!", "Serial Port Error.");
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            watcher.Stop();
        }
    }
