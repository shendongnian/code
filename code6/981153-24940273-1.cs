    public partial class MainForm : Form        
    {
        List<Process> myProcesses = new List<Process>();
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (System.Diagnostics.Process myProcess in myProcesses)
            {
                myProcess.Close();
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
    
        }
    
        private void Startbutton_Click(object sender, EventArgs e)
        {    
            ProcessStartInfo startInfo = new ProcessStartInfo("ffmpeg.exe");
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = "-i " + urltext.Text.Trim() + "?fifo_size=1000000 -map 0:p:" + Channeltext.Text.Trim() + " -vcodec copy -acodec copy -f segment -segment_time " + splittimetext.Text.Trim() + " " + filenametext.Text.Trim() + "-%03d.ts";
            myProcesses.add(System.Diagnostics.Process.Start(startInfo));
        }
    }
