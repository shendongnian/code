    class main : Form
    {
        private TftpServer server;
        public main()
        {
            InitializeComponent();
            this.Load += main_Load;
            this.Closing += main_Closing;
            server = new TftpServer();
            server.OnReadRequest += new TftpServerEventHandler(server_OnReadRequest);
            server.OnWriteRequest += new TftpServerEventHandler(server_OnWriteRequest);
        }
        private void main_Load(object sender, EventArgs e)
        {
            server.Start();
        }
        private void server_OnReadRequest(...) { ... }
        private void server_OnWriteRequest(...) { ... }
        private void main_Closing(object sender, FormClosingEventArgs e)
        {
            server.Dispose();
        }
    }
