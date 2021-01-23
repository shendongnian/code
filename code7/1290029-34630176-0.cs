    public partial class Form1 : Form
    {
        int portSend;
        int portReceive;
        String IPAddr;
        IPEndPoint RemoteIpEndPointReceive;
        IPEndPoint RemoteIpEndPointSend;
        UdpClient udpClientReceive; // ne treba
        UdpClient udpClientSend;
        UdpState udpState; // ne treba
        byte[] calibrationChannel1;
        byte[] calibrationChannel2;
        byte[] calibrationChannel3;
        byte[] calibrationChannel4;
        uint CH1;
        uint CH2;
        uint CH3;
        uint CH4;
        private bool startReceiving;
        private Thread tReceive;
        public Form1()
        {
            InitializeComponent();
            // Initialization of atributes
            Initialization();
        }
        private void Initialization()
        {
            // IPAddress and PORT number
            portSend = 1;
            portReceive = 55056;
            IPAddr = "10.1.52.155";
            
            // Timer for sending message keep-alive
            //timerKeepAlive(5);
            // IpEndPoint for receiving messages
            RemoteIpEndPointReceive = new IPEndPoint(IPAddress.Parse("10.1.52.155"), portReceive); 
            // IpEndPoint for sending messages
            RemoteIpEndPointSend = new IPEndPoint(IPAddress.Parse(IPAddr), portSend);
            // UdpClient for receiving messages
            udpClientReceive = new UdpClient();
        
            // UdpClient for sending messages
            udpClientSend = new UdpClient();
            udpState = new UdpState();
            // Calibration bytes from all 4 channels
            calibrationChannel1 = new byte[4]; 
            calibrationChannel2 = new byte[4];
            calibrationChannel3 = new byte[4];
            calibrationChannel4 = new byte[4];
            startReceiving = false;
            
            // Thread for receiving messages
            tReceive = new Thread(new ThreadStart(() => ReceiveMessages(udpClientSend)));
            tReceive.Start();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
        }
        // *************************************** T I M E R ****************************************************
        private void timerKeepAlive(int seconds)
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = seconds * 1000;
            aTimer.Enabled = true;
        }
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            // Keep alive need to be sent as HEX value
            sendKeepAlive();
        }
        // ######################################################################################################
        // ************************************** S E N D I N G ****************************************************
        private void sendString(string message)
        {
            try
            {
                // Connecting with client
                udpClientSend.Connect(RemoteIpEndPointSend);
                // Converting message to array of bytes
                Byte[] sendBytes = Encoding.ASCII.GetBytes(message);
                // Sending message
                udpClientSend.Send(sendBytes, sendBytes.Length);
                // Adding sent message to text box
                this.txtMeasurements.Invoke((Action)(() =>
                {
                    txtMeasurements.AppendText("Sent: " + message + "!");
                    txtMeasurements.AppendText(Environment.NewLine);
                }));
                // Receiving message
                Byte[] receiveBytes = udpClientSend.Receive(ref RemoteIpEndPointReceive);
                // Converting received bytes to string
                string returnData = Encoding.ASCII.GetString(receiveBytes);
                // Adding received message to text box
                this.txtMeasurements.Invoke((Action)(() =>
                {
                    txtMeasurements.AppendText("Arrived: " + returnData.ToString());
                    txtMeasurements.AppendText(Environment.NewLine);
                }));
                // Closing connection with client
                //udpClientSend.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,
                                "Exception",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation
                                );
            }
        }
        private void sendKeepAlive()
        {
            try
            {
                // Connecting with client
                udpClientSend.Connect(RemoteIpEndPointSend);
                // Creating byte message
                var sendBytes = new byte[] { 0x34 };
                // Sending message
                udpClientSend.Send(sendBytes, sendBytes.Length);
                // Adding sent message to text box
                this.txtMeasurements.Invoke((Action)(() =>
                {
                    txtMeasurements.AppendText("Sent: 0x34 Keep alive!");
                    txtMeasurements.AppendText(Environment.NewLine);
                }));
                // Receiving message
                Byte[] receiveBytes = udpClientSend.Receive(ref RemoteIpEndPointReceive);
                // Converting received bytes to string
                string returnData = Encoding.ASCII.GetString(receiveBytes);
                // Adding received message to text box
                this.txtMeasurements.Invoke((Action)(() =>
                {
                    txtMeasurements.AppendText("Arrived: " + returnData.ToString());
                    txtMeasurements.AppendText(Environment.NewLine);
                }));
                
                //udpClientSend.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,
                                "Exception",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }
        private void sendStartConverting()
        {
            try
            {
                // Connecting with client
                udpClientSend.Connect(RemoteIpEndPointSend);
                // Creating message as array of bytes
                int num = 0x310F;
                var unum = (uint)num;    // Convert to uint for correct >> with negative numbers
                var sendBytes = new[] {
                (byte)(unum >> 8),
                (byte)(unum)
                };
                // Sending message
                udpClientSend.Send(sendBytes, sendBytes.Length);
                // Adding sent message to text box
                this.txtMeasurements.Invoke((Action)(() =>
                {
                    txtMeasurements.AppendText("Sent: 0x310F Start converting!");
                    txtMeasurements.AppendText(Environment.NewLine);
                }));
                // Receving new message 10 times
                //for (int i = 0; i < 20; i++)
                ///{
                    // Receiving message
                    Byte[] receiveBytes = udpClientSend.Receive(ref RemoteIpEndPointReceive);
                    // Conveting received bytes to string
                    string returnData = ByteArrayToString(receiveBytes);
                    
                    // Start receving in thread
                    startReceiving = true;
                    /*
                    // Adding received message to text box
                    this.txtMeasurements.Invoke((Action)(() =>
                    {
                        txtMeasurements.AppendText("Arrived: " + returnData);
                        txtMeasurements.AppendText(Environment.NewLine);
                    }));
                    */
                //}
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,
                                "Exception",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }
        private void sendReadEPROM()
        {
            try
            {
                // Connecting with client
                udpClientSend.Connect(IPAddress.Parse(IPAddr), portSend);
                // Creating byte message
                var sendBytes = new byte[] { 0x32 };
                // Sending message
                udpClientSend.Send(sendBytes, sendBytes.Length);
                // Adding sent message to text box
                this.txtMeasurements.Invoke((Action)(() =>
                {
                    txtMeasurements.AppendText("Sent: 0x32 Read EPROM!");
                    txtMeasurements.AppendText(Environment.NewLine);
                }));
                
                // Receiving message
                Byte[] receiveBytes = udpClientSend.Receive(ref RemoteIpEndPointReceive);
                // Calibartion bytes CH1 - LSB first
                calibrationChannel1[0] = receiveBytes[37];
                calibrationChannel1[1] = receiveBytes[38];
                calibrationChannel1[2] = receiveBytes[39];
                calibrationChannel1[3] = receiveBytes[40];
                CH1 = (uint) byteArrayToDecimal(calibrationChannel1);
                
                // Calibartion bytes CH2 - LSB first
                calibrationChannel2[0] = receiveBytes[41];
                calibrationChannel2[1] = receiveBytes[42];
                calibrationChannel2[2] = receiveBytes[43];
                calibrationChannel2[3] = receiveBytes[44];
                CH2 = (uint) byteArrayToDecimal(calibrationChannel2);
                // Calibartion bytes CH3 - LSB first
                calibrationChannel3[0] = receiveBytes[45];
                calibrationChannel3[1] = receiveBytes[46];
                calibrationChannel3[2] = receiveBytes[47];
                calibrationChannel3[3] = receiveBytes[48];
                CH3 = (uint) byteArrayToDecimal(calibrationChannel3);
                // Calibartion bytes CH4 - LSB first
                calibrationChannel1[0] = receiveBytes[49];
                calibrationChannel1[1] = receiveBytes[50];
                calibrationChannel1[2] = receiveBytes[51];
                calibrationChannel1[3] = receiveBytes[52];
                CH4 = (uint) byteArrayToDecimal(calibrationChannel4);
                // Adding calibration data to text boxes
                Invoke((MethodInvoker)delegate
                {
                    txtCH1.Text = CH1.ToString();
                    txtCH2.Text = CH2.ToString();
                    txtCH3.Text = CH3.ToString();
                    txtCH4.Text = CH4.ToString();
                    txtCH1hex.Text = ByteArrayToString(calibrationChannel1);
                    txtCH2hex.Text = ByteArrayToString(calibrationChannel2);
                    txtCH3hex.Text = ByteArrayToString(calibrationChannel3);
                    txtCH4hex.Text = ByteArrayToString(calibrationChannel4);
                });
                // Converting received bytes to string
                string returnData = ByteArrayToString(receiveBytes);
                // Adding received message to text box
                this.txtMeasurements.Invoke((Action)(() =>
                {
                    txtMeasurements.AppendText("Arrived: " + returnData.ToString());
                    txtMeasurements.AppendText(Environment.NewLine);
                }));
                // Closing connection with client
                //udpClientSend.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,
                                "Exception",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }
        private void sendUnlock()
        {
            try
            {
                // Connecting with client
                udpClientSend.Connect(RemoteIpEndPointSend);
                // Creating byte message
                var sendBytes = new byte[] { 0x33 };
                // Sending message
                udpClientSend.Send(sendBytes, sendBytes.Length);
                // Adding sent message to text box
                this.txtMeasurements.Invoke((Action)(() =>
                {
                    txtMeasurements.AppendText("Sent: 0x33 Unlock!");
                    txtMeasurements.AppendText(Environment.NewLine);
                }));
                
                // Receiving message
                Byte[] receiveBytes = udpClientSend.Receive(ref RemoteIpEndPointReceive);
                // Converting received bytes to string
                string returnData = Encoding.ASCII.GetString(receiveBytes);
                // Adding received message to tex box
                this.txtMeasurements.Invoke((Action)(() =>
                {
                    txtMeasurements.AppendText("Arrived: " + returnData.ToString());
                    txtMeasurements.AppendText(Environment.NewLine);
                }));
                // Closing connection with client
                //udpClientSend.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,
                                "Exception",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }
        private string ByteArrayToString(byte[] ba)
        {
            string hex = BitConverter.ToString(ba);
            return hex.Replace("-", " ");
        }
        private int byteArrayToDecimal(byte[] ba)
        {
            if (BitConverter.IsLittleEndian)
                Array.Reverse(ba); //need the bytes in the reverse order
            return BitConverter.ToInt32(ba, 0);
        }
        // #######################################################################################################
        // *********************************** R E C E I V I N G ****************************************************
        private void ReceiveMessages(UdpClient client)
        {
            try
            {
                int available = client.Available;
                client.Connect(RemoteIpEndPointReceive);
                while(startReceiving)
                {
                    // Receiving message
                    Byte[] receiveBytes = udpClientSend.Receive(ref RemoteIpEndPointReceive);
                    // Adding received message to text box
                    this.txtMeasurements.Invoke((Action) (() => 
                    {
                        txtMeasurements.AppendText("Arrived in thread: " + ByteArrayToString(receiveBytes));
                    }));
                        
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,
                                "Exception",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }
        // ******************************************************************************************************
        private void btnConnect_Click(object sender, EventArgs e)
        {
            // Enabling stop button
            btnStop.Enabled = true;
            // Firstly we need to "lock" data logger to our machine
            sendString("lock");
            // Read the EEPROM to obtain calibration information for the channels
            sendReadEPROM();
            // Take measurements 0, 1, 2, 3 on channels 1, 2, 3, 4.
            // Note that measurements are stored MSB-first while calibration values 
            // are stored LSB - first.
            sendStartConverting();
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            startReceiving = false;
            btnStop.Enabled = false;
        }
    }
