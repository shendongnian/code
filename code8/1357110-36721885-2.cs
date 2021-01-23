    public partial class Main : Form
    {
        Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public Main()
        {
            InitializeComponent();
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            sck.Connect("127.0.0.1", 8);
            MessageBox.Show("Connected");
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            int s = sck.Send(Encoding.Default.GetBytes(txtMsg.Text));
            if (s>0)
            {
                MessageBox.Show("Message Sent..");
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            sck.Close();
            sck.Dispose();
            Close();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            //lis
        }
    }
