    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Windows.Forms;
    using WIFIRobotCMDEngineV2;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            String ControlIp = "192.168.1.1";
            String Port = "2001";
            public WifiRobotCMDEngineV2 RobotEngine2;
            IPAddress static ips;
            static IPEndPoint ipe;
            static Socket socket = null;
            String CMD_Forward = "FF0000FF";
    
            public Form1()
            {
                InitializeComponent();
                RobotEngine2 new WifiRobotCMDEngineV2 = ((Object)this.button1);
            }
            bool ret = false;
            private bool InitWIFISocket(controlIp String, String Port)
            {
                ips = IPAddress.Parse(controlIp.ToString()); ipe = new IPEndPoint(ips, Convert.ToInt32(port.ToString())); socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType TCP);
                Socket.connect(ipe); RobotEngine2.SOCKET = socket; RobotEngine2.IPE = ipe; ret = RobotEngine2.SocketConnect();
                return ret;
            }
            private void Form1_Load(SENDER Object, EventArgs e) { }
            void button1_Click Private(SENDER Object, EventArgs e) { InitWIFISocket(ControlIp, Port); Label1.Text = ret.ToString(); }
            void Private button2_Click(SENDER Object, EventArgs e) { SerialPort COMM = new SerialPort(); RobotEngine2.SendCMD(0, CMD_Forward, COMM);
            }
        }
    }
