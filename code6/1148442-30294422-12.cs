    public partial class Form1 : Form
    {
        private Server server;
        public Form1()
        {
            InitializeComponent();
            server = new Server { Port = 9180, MaxQueuedConnections = 100 };
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            server.ClientConnected += OnClientConnected;
            server.ClientDisconnected += OnClientDisconnected;
        }
        private void OnClientDisconnected(object sender, ConnectedArgs e)
        {
            this.Invoke(new Action(() => this.textBox1.AppendText("A Client disconnected.\n")));
        }
        private void OnClientConnected(object sender, ConnectedArgs e)
        {
            this.Invoke(new Action(() => 
            {
                this.textBox1.AppendText("New Client Connected.\n");
                e.ConnectedClient.DataReceived += OnClientSentDataToServer;
            }));
        }
        private void OnClientSentDataToServer(object sender, string e)
        {
            this.Invoke(new Action(() => this.textBox1.AppendText($"{e}\n")));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.AppendText("Server starting.\n");
            server.Start();
            this.textBox1.AppendText("Server running.\n");
        }
    }
