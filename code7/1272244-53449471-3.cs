     using System;
     using System.IO;
     using System.Net;
     using System.Net.Sockets;
     using System.Text;
     using System.Threading;
     using System.Windows.Forms;
     namespace Clienf_fileSend
     {
      public partial class Form1 : Form
      {
        Socket Client = null;
        Thread trRecive;
        const int sizeByte = 1024;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                IPEndPoint IP = new IPEndPoint(IPAddress.Parse(textBox1.Text), 5050);
                Client.Connect(IP);
                button1.Enabled = false;
                button2.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SendFile(object FName)
        {
            try
            {
                FileInfo inf = new FileInfo((string)FName);
                progressBar1.Invoke((MethodInvoker)delegate
                {
                    progressBar1.Maximum = (int)inf.Length;
                    progressBar1.Value = 0;
                });
                FileStream f = new FileStream((string)FName, FileMode.Open);
                byte[] fsize = Encoding.UTF8.GetBytes(inf.Length.ToString() + ":");
                byte[] fname = Encoding.UTF8.GetBytes(inf.Name + "?");
                byte[] fInfo = new byte[sizeByte];
                fsize.CopyTo(fInfo, 0);
                fname.CopyTo(fInfo, fsize.Length);
                Client.Send(fInfo);
                   if (sizeByte> f.Length)
            {
                byte[] b = new byte[f.Length];
                f.Seek(0, SeekOrigin.Begin);
                f.Read(b, 0, (int)f.Length);
                Client.Send(b);
            }
            else
            {
                for (int i = 0; i < (f.Length - sizeByte); i = i + sizeByte)
                {
                    byte[] b = new byte[sizeByte];
                    f.Seek(i, SeekOrigin.Begin);
                    f.Read(b, 0, b.Length);
                    Client.Send(b);
                    progressBar1.Invoke((MethodInvoker)delegate
                    {
                        progressBar1.Value = i;
                    });
                    if (i + sizeByte >= f.Length - sizeByte)
                    {
                        progressBar1.Invoke((MethodInvoker)delegate
                        {
                            progressBar1.Value = (int)f.Length;
                        });
                        int ind = (int)f.Length - (i + sizeByte);
                        byte[] ed = new byte[ind];
                        f.Seek(i + sizeByte, SeekOrigin.Begin);
                        f.Read(ed, 0, ed.Length);
                        Client.Send(ed);
                    }
                }
            }
                f.Close();
                Thread.Sleep(1000);
                Client.Send(Encoding.UTF8.GetBytes("!endf!"));
                Thread.Sleep(1000);
                MessageBox.Show("Send File " + ((float)inf.Length / 1024).ToString() + "  KB");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdl = new OpenFileDialog();
            if (fdl.ShowDialog() == DialogResult.OK)
            {
                trRecive = new Thread(new ParameterizedThreadStart(SendFile));
                trRecive.Start(fdl.FileName);
            }
            fdl = null;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                trRecive.Abort();
                Environment.Exit(Environment.ExitCode);
            }
            catch (Exception)
            {
                Environment.Exit(Environment.ExitCode);
            }
        }
       }
     }
