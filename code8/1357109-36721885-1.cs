    public partial class Main : Form
    {
        private static Listener _listener;
        public Main()
        {
            InitializeComponent();
            _listener = new Listener(8);
            _listener.SocketAccepted += new Listener.SocketAcceptedHandler(_listenerSocketAccepted);
            _listener.Start();
        }
        private void _listenerSocketAccepted(Socket e)
        {
            Client client = new Client(e);
            client.Received += new Client.ClientReceivedHandler(client_Received);
            client.Disconnected += new Client.ClientDiscconnectedHandler(client_Disconnected);
            Invoke((MethodInvoker)delegate
            {
                ListViewItem i=new ListViewItem();
                i.Text = client.EndPoint.ToString();
                i.SubItems.Add(client.ID);
                i.SubItems.Add("XXX");
                i.SubItems.Add("XXX");
                i.Tag = client;
                listViewClients.Items.Add(i);
                //textBox1.Text = "New Connection : " + e.RemoteEndPoint + "    Time : " + DateTime.Now;
            });
        }
        private void client_Disconnected(Client sender)
        {
            Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < listViewClients.Items.Count; i++)
                {
                    Client client=listViewClients.Items[i].Tag as Client;
                    if (client.ID==sender.ID)
                    {
                        listViewClients.Items.RemoveAt(i);
                        break;
                    }
                }
            });
        }
        private void client_Received(Client sender, byte[] data)
        {
            Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < listViewClients.Items.Count; i++)
                {
                    Client client = listViewClients.Items[i].Tag as Client;
                    if (client.ID == sender.ID)
                    {
                        listViewClients.Items[i].SubItems[2].Text = Encoding.Default.GetString(data);
                        listViewClients.Items[i].SubItems[3].Text = DateTime.Now.ToString();
                        break;
                    }
                }
            });
        }
        private void Main_Load(object sender, EventArgs e)
        {
        }
    }
    
