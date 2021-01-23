        using System;
        using System.Linq;
        using System.Text;
        using System.Windows.Forms;
        using System.Threading;
        using System.Net.Sockets;
        using System.Net;
        using System.IO;
        namespace Server_FileSend
        {
         public partial class Form1 : Form
        {
        Socket Server = null;
        Socket Client = null;
        Thread trStart;
        Thread trRecive;
        const int sizeByte = 1024;
        public Form1()
        {
            InitializeComponent();
        }
        private void ReciveFile()
        {
            while (true)
            {
                try
                {
                    byte[] b = new byte[sizeByte];
                    int rec = 1;
                    int vp = 0;
                    rec = Client.Receive(b);
                    int index;
                    for (index = 0; index < b.Length; index++)
                        if (b[index] == 63)
                            break;
                    string[] fInfo = Encoding.UTF8.GetString(b.Take(index).ToArray()).Split(':');
                    this.Invoke((MethodInvoker)delegate
                    {
                        progressBar1.Maximum = int.Parse(fInfo[0]);
                    });
                      string path = Application.StartupPath + "\\Downloads\\";
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    FileStream fs = new FileStream(path + fInfo[1], FileMode.Append, FileAccess.Write);
                    string strEnd;
                    while (true)
                    {
                        rec = Client.Receive(b);
                        vp = vp + rec;
                        strEnd = ((char)b[0]).ToString() + ((char)b[1]).ToString() + ((char)b[2]).ToString() + ((char)b[3]).ToString() + ((char)b[4]).ToString() + ((char)b[5]).ToString();
                        if (strEnd == "!endf!")
                        {
                            fs.Flush();
                            fs.Close();
                            MessageBox.Show("Receive File " + ((float)(float.Parse(fInfo[0]) / 1024)).ToString() + "  KB");
                            break;
                        }
                        fs.Write(b, 0, rec);
                        this.Invoke((MethodInvoker)delegate
                        {
                            progressBar1.Value = vp;
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Form1_FormClosing(null, null);
                }
            }
        }
        private void StartSocket()
        {
            Server.Listen(1);
            Client = Server.Accept();
            trRecive = new Thread(new ThreadStart(ReciveFile));
            trRecive.Start();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            IPEndPoint IP = new IPEndPoint(IPAddress.Any, 5050);
            Server.Bind(IP);
            trStart = new Thread(new ThreadStart(StartSocket));
            trStart.Start();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                trRecive.Abort();
                trStart.Abort();
                Environment.Exit(Environment.ExitCode);
            }
            catch (Exception)
            {
                Environment.Exit(Environment.ExitCode);
            }
        }
       }
     }
