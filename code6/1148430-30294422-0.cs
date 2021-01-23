    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                Task.Run(() => serverfunction());
            }
            private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
            }
            public void serverfunction()
            {
                int port = 80;
                IPAddress localAddr = IPAddress.Parse("192.168.1.68");
                TcpListener server = new TcpListener(localAddr, port);
                server.Start();
                byte[] bytes = new byte[2048];
                string data;
                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    NetworkStream stream = client.GetStream();
                    int i;
                    i = stream.Read(bytes, 0, bytes.Length);
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    Global.message = StripExtended(data);
                    Console.WriteLine(Global.message);
                }
            }
            static string StripExtended(string arg)
            {
                StringBuilder buffer = new StringBuilder(arg.Length); //Max length
                foreach (char ch in arg)
                {
                    UInt16 num = Convert.ToUInt16(ch);//In .NET, chars are UTF-16
                    //The basic characters have the same code points as ASCII, and the extended characters are bigger
                    if ((num >= 32u) && (num <= 126u)) buffer.Append(ch);
                }
                return buffer.ToString();
            }
        }
        public class Global
        {
            public static string message = "";
        }
    }
