    public partial class Form1 : Form
    {
        string serverIp = "127.0.0.1";
        int serverPort = 4200;
        public Form1()
        {
                InitializeComponent();
                IPAddress localAdd = IPAddress.Parse(serverIp);
                TcpListener listener = new TcpListener(localAdd, serverPort);
         }
    }
