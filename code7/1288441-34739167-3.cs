    public partial class Form2 : Form
    {
        public Form2(NetComm.Host host)
        {
            _host = host;
            InitializeComponent();
        }
        NetComm.Host _host;
        private void Form2_Load(object sender, EventArgs e)
        {
            button1.Click += Button1_Click;
        }
        // there is a button to close the connection on the host form.
        private void Button1_Click(object sender, EventArgs e)
        {
            _host.CloseConnection();
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            _host.CloseConnection();
        }
    }
