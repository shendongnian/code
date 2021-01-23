    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Net;
    using System.Net.Sockets;
    using System.IO;
    using System.Threading;
    using System.Net.NetworkInformation;
    namespace chat
    {
      public partial class Form1 : Form
      {
        private const int MyPort = 2522;
        private UdpClient Client;
        public Form1()
        {
            InitializeComponent();
            // Create the UdpClient and start listening.
            Client = new UdpClient(MyPort);
            Client.BeginReceive(DataReceived, null);
        }
        private void DataReceived(IAsyncResult ar)
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, MyPort);
            byte[] data;
            try
            {
                data = Client.EndReceive(ar, ref ip);
                if (data.Length == 0)
                    return; // No more to receive
                Client.BeginReceive(DataReceived, null);
            }
            catch (ObjectDisposedException)
            {
                return; // Connection closed
            }
            // Send the data to the UI thread
            this.BeginInvoke((Action<IPEndPoint, string>)DataReceivedUI, ip, Encoding.UTF8.GetString(data));
        }
        private void DataReceivedUI(IPEndPoint endPoint, string data)
        {
            richTextBox2.AppendText(data + Environment.NewLine);
            label4.Text = ("[" + endPoint.ToString() + "]");
            //richTextBox2.AppendText("[" + endPoint.ToString() + "] " + data + Environment.NewLine);
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            pictureBox1.BackColor = colorDialog1.Color;
            this.BackColor = colorDialog1.Color;
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }
        
        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                {
                    Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    string IpAddress = textBox3.Text;
                    IPAddress serverAddr = IPAddress.Parse(IpAddress);
                    IPEndPoint endPoint = new IPEndPoint(serverAddr, 2522);
                    string text = textBox4.Text + ": " + richTextBox1.Text;
                    byte[] send_buffer = Encoding.ASCII.GetBytes(text);
                    sock.SendTo(send_buffer, endPoint);
                    richTextBox2.Text = richTextBox2.Text + textBox4.Text + ": " + richTextBox1.Text + Environment.NewLine;
                    richTextBox1.Text = "";
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var addr in Dns.GetHostEntry(string.Empty).AddressList)
            {
                if (addr.AddressFamily == AddressFamily.InterNetwork)
                    label5.Text = "" + addr;
            }
        }
      }
    }
