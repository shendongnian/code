    delegate void AddContentDelegate(string Text);
    public partial class Form1 : Form
    {
        AddContentDelegate AddContent;
        public Form1()
        {
            InitializeComponent();
            AddContent = new AddContentDelegate(AddContentFunction);
        }
        void AddContentFunction(string Text)
        {
            MessageBox.Show(Text);
            textBox1.Text += Text + "\r\n";
        }
        void myProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            BeginInvoke(AddContent, e.Data);
        }
        void myProcess_Exited(object sender, EventArgs e)
        {
            MessageBox.Show("Exit");
        }
        void myProcess_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            MessageBox.Show("error", e.Data);
        } 
        private void button1_Click(object sender, EventArgs e)
        {
            myProcess = new System.Diagnostics.Process();
            myProcess.StartInfo.FileName = "sqlplus.exe";
            myProcess.StartInfo.WorkingDirectory = "";
            myProcess.StartInfo.Arguments = "-s hr/hr@XE";
            myProcess.StartInfo.RedirectStandardInput = true;
            myProcess.StartInfo.RedirectStandardOutput = true;
            myProcess.StartInfo.RedirectStandardError = true;
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.OutputDataReceived += new DataReceivedEventHandler(myProcess_OutputDataReceived);
            myProcess.ErrorDataReceived += new DataReceivedEventHandler(myProcess_ErrorDataReceived);
            myProcess.Exited += new EventHandler(myProcess_Exited);
            myProcess.Start();
            myProcess.BeginErrorReadLine();
            myProcess.BeginOutputReadLine();
            myProcess.StandardInput.WriteLine("@C:\\Users\\sj0087652\\Documents\\trial_script.sql");
            myProcess.Close(); 
        }
        public System.Diagnostics.Process myProcess;
    }
