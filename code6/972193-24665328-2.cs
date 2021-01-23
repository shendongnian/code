    public partial class Form1 : Form
    {
        string OutputData;
        public Form1()
        {
            InitializeComponent();
        }
        public ProcessStartInfo SetProcStartInfo(string Command)
        {
            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd.exe", "/c " + Command);
            procStartInfo.WorkingDirectory = @"C:\Windows";
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            procStartInfo.RedirectStandardOutput = true;
            return procStartInfo;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo procStartInfo = SetProcStartInfo(this.textBox1.Text);
            using (Process proc1 = Process.Start(procStartInfo))
            {
                proc1.EnableRaisingEvents = true;
                proc1.OutputDataReceived += OnOutputDataReceived;
                proc1.BeginOutputReadLine();
            }
        }
        void OnOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                this.OutputData += e.Data + Environment.NewLine;
                SetText(this.OutputData);
            }
        }
        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            if (this.textBox2.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBox2.Text = text;
            }
        }
    }
