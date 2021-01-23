    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            // start the animation
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            // start the job
            btnImport.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
        }
        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadExcel();
        }
        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnImport.Enabled = true;
            progressBar1.Visible = false;
        }
        private void LoadExcel()
        {
            // some work takes 5 sec
            Thread.Sleep(5000);
        }
    }
