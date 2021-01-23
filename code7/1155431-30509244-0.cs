    public partial class Form1 : Form
    {
        BackgroundWorker _worker = new BackgroundWorker();
        SynchronizationContext _syncContext;
        public Form1()
        {
            InitializeComponent();
            _syncContext = SynchronizationContext.Current;
        }
        private void btnLoadForm_Click(object sender, EventArgs e)
        {
            _worker.WorkerReportsProgress = true;
            _worker.WorkerSupportsCancellation = true;
            _worker.DoWork += new DoWorkEventHandler(HandleDoWork);
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(HandleWorkerCompleted);
            _worker.ProgressChanged += new ProgressChangedEventHandler(HandleProgressChanged);
            _worker.RunWorkerAsync();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_worker.WorkerSupportsCancellation)
            {
                _worker.CancelAsync();
            }
        }
        private void HandleDoWork(object sender, DoWorkEventArgs e)
        {
            // DO Any work to instantiate the form
            System.Threading.Thread.Sleep(2000);
            if (_worker.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                Form2 newForm = new Form2();
                newForm.ShowDialog();
            }
        }
        private void HandleProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // DO Progress Bar Updates Here
            SendOrPostCallback callback = new SendOrPostCallback((o) =>
            {
                label1.Text = "This is my Async content";
            });
            _syncContext.Send(callback, null);
        }
        private void HandleWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // DO Any completed step items here
        }
    }
