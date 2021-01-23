    public partial class Form1 : Form
    {
        private ClientConnection client;
        public Form1()
        {
            InitializeComponent();
            client = new ClientConnection();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            client.ServerMessageArrived += (s, message) =>
            {
                Console.WriteLine(message);
                client.SendMessage($"{message} received by server.");
            };
            client.Connected += (s, args) => Console.WriteLine("Connected.");
            client.ConnectToServerAsync("192.168.1.68", 80);
        }
    }
