    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
        }
        private bool done = true;
        int percentComplete = 1;
        internal bool ImportData(IList<string> filenames)
        {
            try
            {
                // Long running task around 5 to 10 minutes
                return true;
            }
            catch (Exception ex)
            {
                // returning true to break from th display progress loop
                return true;
            }
        }
        private void InitializeBackgroundWorker()
        {
            backgroundWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            backgroundWorker.ProgressChanged +=new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
        }
        private void button1_Click(System.Object sender,System.EventArgs e)
        {
            //fd is Browse dialog to select files in my case
            if (fd.ShowDialog() == DialogResult.OK)
            {
                var flist = fd.FileNames.ToList();                
                // Disable the Start button until the asynchronous operation is done.
                this.startButton.Enabled = false;
                if (!backgroundWorker.IsBusy)
                {
                    this.Cursor = Cursors.WaitCursor;
                    backgroundWorker.RunWorkerAsync(flist);
                }
                else
                {
                    backgroundWorker.CancelAsync();
                }
            }
        }
        private void DisplayProgress(BackgroundWorker worker)
        {
            try
            {
                percentComplete = 1;
                while (done)
                {
                    Thread.Sleep(500);
                    // Report progress
                    if (percentComplete == 100)
                        percentComplete = 1;
                    worker.ReportProgress(++percentComplete);
                }
            }
            catch (Exception e)
            {
            }
        }
        // This event handler is where the actual,
        // potentially time-consuming work is done.
        private void backgroundWorker_DoWork(object sender,DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                new Thread(() =>
                {
                    DisplayProgress(worker);
                }).Start();
                done = ImportData((List<string>) e.Argument);
                worker.ReportProgress(100);
                e.Result = "Converted " + Path.GetFileName(((List<string>) e.Argument)[0]) + " successfully.";
            }
        }
        // This event handler deals with the results of the background operation.
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled
                // the operation.
                // Note that due to a race condition in
                // the DoWork event handler, the Cancelled
                // flag may not have been set, even though
                // CancelAsync was called.               
            }
            else
            {
                // Finally, handle the case where the operation succeeded.
                listView.Items.Add(new ListViewItem(Text = e.Result.ToString()));
                this.Cursor = Cursors.Arrow;
            }
            startButton.Text = "Start";
            startButton.Enabled = true;
        }
        // This event handler updates the progress bar.
        private void backgroundWorker_ProgressChanged(object sender,ProgressChangedEventArgs e)
        {
            this.progressBar.Value = e.ProgressPercentage;
        }
    }
