    public partial class Form1 : Form
    {
        public int cpuLoad;
        private PerformanceCounter cpuCounter;
        static public string curIP;
        public static string get_localip = GetLocalIP();
    
        public Form1()
        {
            InitializeComponent();
            InitialiseCPUCounter();
            timer1.Start();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            lblServerIP.Text += " " + get_localip;
        }
        private TcpListener _listener;
    
        public void StartServer()
        {
            System.Net.IPAddress localIPAddress = System.Net.IPAddress.Parse(get_localip);
            IPEndPoint ipLocal = new IPEndPoint(localIPAddress, 8888);
            _listener = new TcpListener(ipLocal);
            _listener.Start();
            WaitForClientConnect();
    
        }
        private void WaitForClientConnect()
        {
            object obj = new object();
            _listener.BeginAcceptTcpClient(new System.AsyncCallback(OnClientConnect), obj);
        }
        public void OnClientConnect(IAsyncResult asyn)
        {
            try
            {
                TcpClient clientSocket = default(TcpClient);
                // Socket sck;
    
                clientSocket = _listener.EndAcceptTcpClient(asyn);
                IPAddress add = IPAddress.Parse(((IPEndPoint)clientSocket.Client.RemoteEndPoint).Address.ToString());
                curIP = add.ToString();
    
                //Use this.Invoke or this.BeginInvoke
                this.Invoke(new Action(() =>
                {
                    lstIP.items.add("client connected with ip" + curIP);
                    MessageBox.Show("cleint connected with ip:" + curIP);
                }));
    
                HandleClientRequest clientReq = new HandleClientRequest(clientSocket);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
    
            WaitForClientConnect();
        }
    
        public void btnStart_Click(object sender, EventArgs e)
        {
            StartServer();
        }
        private void InitialiseCPUCounter()
        {
            cpuCounter = new PerformanceCounter(
            "Processor",
            "% Processor Time",
            "_Total",
            true
            );
        }
    
        private void timer1_Tick(object sender, EventArgs e)
        {
            cpuLoad = Convert.ToInt32(cpuCounter.NextValue());
            this.txtCPUusage.Text = cpuLoad.ToString() + "%";
        }
        static public string GetLocalIP()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "127.0.0.1";
        }
    }
