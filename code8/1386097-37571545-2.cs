    public partial class MainWindow : Window
    {
        private BackgroundWorker backgroundWorker = new BackgroundWorker();
        private MessageWithProgressBar progressWindow;
        public MessageWithProgressBar()
        {
            InitializeComponent();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.ProgressChanged += ProgressChanged;
            backgroundWorker.DoWork += DoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            progressWindow = new MessageWithProgressBar();
            progressWindow.Owner = this;
            progressWindow.Show();
            backgroundWorker.RunWorkerAsync();
        }
    
        private void DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            int numSteps = 11;
            int currentStep = 0;
            int progress = 0;
            CreateFilesInA();
            currentStep += 1;
            progress = (int)((float)currentStep / (float)numSteps * 100.0);
            worker.ReportProgress(progress);
            CreateFilesInB();
            currentStep += 1;
            progress = (int)((float)currentStep / (float)numSteps * 100.0);
            worker.ReportProgress(progress);
            // All other steps here
            ...
        }
    
        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressWindow.progress.Value = e.ProgressPercentage;
        }
    
        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressWindow.Close();
            WindowMsgGenDB msg = new WindowMsgGenDB();
            msg.Show();
        }
    }
