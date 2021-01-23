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
        private void button1_Click_1(object sender, EventArgs e)
        {
            ProcessStartInfo procStartInfo = SetProcStartInfo(this.textBox1.Text);
            using (Process proc1 = Process.Start(procStartInfo))
            {
                using (StreamReader SW1 = proc1.StandardOutput)
                {
                    this.textBox2.Text += SW1.ReadToEnd();
                }
            }
        }
