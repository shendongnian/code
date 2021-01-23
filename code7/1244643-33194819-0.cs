    public partial class BackgroundWorkerSample : Form
    {
        private BackgroundWorker work = null;
        public string CustomMessage { get; set; }
        public BackgroundWorkerSample()
        {
            InitializeComponent();
            work = new BackgroundWorker();
            work.WorkerSupportsCancellation = true;
            work.WorkerReportsProgress = true;
            work.DoWork += worker_DoWork;
            work.ProgressChanged += worker_ProgressChanged;
            work.RunWorkerCompleted += worker_RunWorkerCompleted;
        }
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = CustomMessage;
            }
            else
            {
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = $"Result is : {e.Result}";
            }
        }
        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatus.Text = $"Calculating result... ({ e.ProgressPercentage }%)";
        }
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                if (work.CancellationPending == true)
                {
                    e.Cancel = true;
                    return;
                }
                work.ReportProgress(i);
                System.Threading.Thread.Sleep(250);
            }
            e.Result = 42;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            work.RunWorkerAsync();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            CustomMessage = "Calculation cancelled by user";
            work.CancelAsync();
        }
    }
