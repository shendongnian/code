             private BackgroundWorker worker;
        private BusyForm busyForm = new BusyForm();
        private string progressText;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            progressText = "Entering button click event handler" + Environment.NewLine;
            busyForm.SetText(progressText);
            worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
            busyForm.ShowDialog();
        }
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            busyForm.Hide();
        }
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            progressText += "Begining First Phase now" + Environment.NewLine;
            this.Invoke((MethodInvoker)delegate
            {
                busyForm.SetText(progressText);
            });
            PhaseOne();
            progressText += "First Phase complete..." + Environment.NewLine + "Begining Second Phase now" + Environment.NewLine;
            this.Invoke((MethodInvoker)delegate
            {
                busyForm.SetText(progressText);
            });
            PhaseTwo();
            progressText += "Execution Complete";
            this.Invoke((MethodInvoker)delegate
            {
                busyForm.SetText(progressText);
            });
            System.Threading.Thread.Sleep(2000); //Just adding a delay to let you see this is shown
        }
        private void PhaseOne()
        {
            System.Threading.Thread.Sleep(2000);
        }
        private void PhaseTwo()
        {
            System.Threading.Thread.Sleep(2000);
        }
